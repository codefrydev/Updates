---
title: "Network transfer visualizer"
author: "PrashantUnity"
weight: 116
date: 2026-05-31
lastmod: 2026-05-31
dateString: May 2026
description: "Compare direct, client-server, and peer-to-peer torrent distribution models."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Network Transfer Visualizer" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "Tailwind CSS", "Torrent", "Networking", "Peer-to-Peer", "codefrydev", "CFD"]
keywords: [ "Tailwind CSS", "Torrent", "Networking", "Peer-to-Peer", "P2P", "Client-Server", "codefrydev", "CFD"]
hideMeta: true
---
# Network Transfer Visualizer

An interactive canvas simulation comparing three data distribution models: direct (1-to-1), client-server (1-to-many), and torrent swarm (many-to-many). Pick a mode, start the simulation, and watch how packets spread across the network.

{{< rawhtml >}}
<script src="https://cdn.tailwindcss.com"></script>
<style>
    #ntv-root {
        width: 100vw;
        max-width: 100vw;
        margin-left: calc(50% - 50vw);
        margin-right: calc(50% - 50vw);
        height: min(88vh, 920px);
        min-height: 760px;
    }
    #ntv-canvasContainer {
        min-height: 620px;
    }
    @media (max-width: 768px) {
        #ntv-root {
            min-height: 640px;
            height: 78vh;
        }
        #ntv-canvasContainer {
            min-height: 460px;
        }
    }
</style>
<div id="ntv-root" class="not-prose bg-zinc-950 text-zinc-100 font-sans flex flex-col rounded-lg overflow-hidden border border-zinc-800">
    <div class="p-4 sm:p-6 border-b border-zinc-800 bg-zinc-900 flex flex-col sm:flex-row sm:items-center justify-between gap-4 z-10">
        <div>
            <h2 class="text-lg sm:text-xl font-semibold tracking-tight text-white m-0">Network Transfer Visualizer</h2>
            <p class="text-sm text-zinc-400 mt-1 mb-0">Comparing data distribution models.</p>
        </div>
        <div class="flex flex-wrap gap-3 items-center">
            <select id="ntv-modeSelect" class="bg-zinc-800 border border-zinc-700 text-sm rounded-md px-3 py-2 outline-none focus:border-zinc-500 text-zinc-100">
                <option value="direct">Direct (1-to-1)</option>
                <option value="server">Client-Server (1-to-Many)</option>
                <option value="torrent">Torrent Swarm (Many-to-Many)</option>
            </select>
            <button id="ntv-startBtn" type="button" class="bg-white text-black px-5 py-2 rounded-md text-sm font-medium hover:bg-zinc-200 transition-colors">
                Start Simulation
            </button>
            <button id="ntv-resetBtn" type="button" class="bg-zinc-800 text-white border border-zinc-700 px-5 py-2 rounded-md text-sm font-medium hover:bg-zinc-700 transition-colors">
                Reset
            </button>
        </div>
    </div>
    <div class="flex-1 relative w-full min-h-0" id="ntv-canvasContainer">
        <canvas id="ntv-simCanvas" style="display:block;width:100%;height:100%;"></canvas>
    </div>
</div>
<script>
(function () {
    const canvas = document.getElementById('ntv-simCanvas');
    const ctx = canvas.getContext('2d');
    const container = document.getElementById('ntv-canvasContainer');

    let nodes = [];
    let packets = [];
    let animationId;
    let isRunning = false;
    let currentMode = 'direct';
    let layoutRadius = 200;
    let nodeRadius = 32;

    function getLayoutMetrics() {
        const size = Math.min(canvas.width, canvas.height);
        layoutRadius = Math.max(180, Math.min(size * 0.34, 320));
        nodeRadius = Math.max(28, Math.min(40, layoutRadius * 0.13));
        return { layoutRadius, nodeRadius };
    }

    function resize() {
        canvas.width = container.clientWidth;
        canvas.height = container.clientHeight;
        getLayoutMetrics();
        if (!isRunning) {
            initSimulation(currentMode);
        } else {
            draw();
        }
    }
    window.addEventListener('resize', resize);

    class Node {
        constructor(x, y, label, isSource = false) {
            this.x = x;
            this.y = y;
            this.label = label;
            this.progress = isSource ? 100 : 0;
            this.isSource = isSource;
            this.radius = nodeRadius;
        }

        draw() {
            ctx.beginPath();
            ctx.arc(this.x, this.y, this.radius, 0, Math.PI * 2);
            ctx.fillStyle = this.progress === 100 ? '#10b981' : '#27272a';
            ctx.fill();
            ctx.lineWidth = 3;
            ctx.strokeStyle = this.isSource ? '#10b981' : '#52525b';
            ctx.stroke();

            if (!this.isSource) {
                ctx.beginPath();
                ctx.arc(this.x, this.y, this.radius + 8, -Math.PI / 2, (-Math.PI / 2) + (Math.PI * 2 * (this.progress / 100)));
                ctx.strokeStyle = '#3b82f6';
                ctx.lineWidth = 4;
                ctx.stroke();
            }

            ctx.fillStyle = '#ffffff';
            ctx.font = `${Math.round(this.radius * 0.55)}px sans-serif`;
            ctx.textAlign = 'center';
            ctx.fillText(this.label, this.x, this.y + this.radius + 28);

            ctx.fillStyle = this.progress === 100 ? '#000000' : '#ffffff';
            ctx.font = `bold ${Math.round(this.radius * 0.5)}px sans-serif`;
            ctx.fillText(`${Math.floor(this.progress)}%`, this.x, this.y + 5);
        }
    }

    class Packet {
        constructor(source, target, speed) {
            this.source = source;
            this.target = target;
            this.progress = 0;
            this.speed = speed;
            this.active = true;
        }

        update() {
            this.progress += this.speed;
            if (this.progress >= 1) {
                this.active = false;
                if (this.target.progress < 100) {
                    this.target.progress = Math.min(100, this.target.progress + 5);
                }
            }
        }

        draw() {
            if (!this.active) return;
            const currentX = this.source.x + (this.target.x - this.source.x) * this.progress;
            const currentY = this.source.y + (this.target.y - this.source.y) * this.progress;

            ctx.beginPath();
            ctx.arc(currentX, currentY, 6, 0, Math.PI * 2);
            ctx.fillStyle = '#60a5fa';
            ctx.fill();
        }
    }

    function initSimulation(mode) {
        nodes = [];
        packets = [];
        currentMode = mode;
        getLayoutMetrics();
        const cx = canvas.width / 2;
        const cy = canvas.height / 2;
        const spread = layoutRadius;

        if (mode === 'direct') {
            nodes.push(new Node(cx - spread, cy, 'Sender PC', true));
            nodes.push(new Node(cx + spread, cy, 'Receiver PC', false));
        } else if (mode === 'server') {
            nodes.push(new Node(cx, cy, 'Central Server', true));
            for (let i = 0; i < 6; i++) {
                const angle = (Math.PI * 2 * i) / 6;
                nodes.push(new Node(cx + Math.cos(angle) * spread, cy + Math.sin(angle) * spread, `Client ${i + 1}`, false));
            }
        } else if (mode === 'torrent') {
            nodes.push(new Node(cx, cy, 'Initial Seeder', true));
            for (let i = 0; i < 6; i++) {
                const angle = (Math.PI * 2 * i) / 6;
                nodes.push(new Node(cx + Math.cos(angle) * spread, cy + Math.sin(angle) * spread, `Peer ${i + 1}`, false));
            }
        }
        draw();
    }

    function animate() {
        if (!isRunning) return;
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        if (Math.random() < 0.1) {
            if (currentMode === 'direct') {
                if (nodes[1].progress < 100) packets.push(new Packet(nodes[0], nodes[1], 0.02));
            } else if (currentMode === 'server') {
                const incompleteClients = nodes.filter(n => !n.isSource && n.progress < 100);
                if (incompleteClients.length > 0) {
                    const target = incompleteClients[Math.floor(Math.random() * incompleteClients.length)];
                    packets.push(new Packet(nodes[0], target, 0.008));
                }
            } else if (currentMode === 'torrent') {
                const activeSenders = nodes.filter(n => n.progress > 0);
                const incompletePeers = nodes.filter(n => n.progress < 100);

                if (incompletePeers.length > 0 && activeSenders.length > 0) {
                    for (let i = 0; i < 3; i++) {
                        const sender = activeSenders[Math.floor(Math.random() * activeSenders.length)];
                        const target = incompletePeers[Math.floor(Math.random() * incompletePeers.length)];
                        if (sender !== target) {
                            packets.push(new Packet(sender, target, 0.015));
                        }
                    }
                }
            }
        }

        for (let i = packets.length - 1; i >= 0; i--) {
            packets[i].update();
            packets[i].draw();
            if (!packets[i].active) packets.splice(i, 1);
        }

        nodes.forEach(node => node.draw());

        const allDone = nodes.every(n => n.progress === 100);
        if (allDone) {
            isRunning = false;
            document.getElementById('ntv-startBtn').innerText = 'Completed';
        } else {
            animationId = requestAnimationFrame(animate);
        }
    }

    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.strokeStyle = '#27272a';
        ctx.lineWidth = 2;

        if (currentMode === 'server' || currentMode === 'direct') {
            nodes.forEach((node, index) => {
                if (index > 0) {
                    ctx.beginPath();
                    ctx.moveTo(nodes[0].x, nodes[0].y);
                    ctx.lineTo(node.x, node.y);
                    ctx.stroke();
                }
            });
        } else if (currentMode === 'torrent') {
            for (let i = 0; i < nodes.length; i++) {
                for (let j = i + 1; j < nodes.length; j++) {
                    ctx.beginPath();
                    ctx.moveTo(nodes[i].x, nodes[i].y);
                    ctx.lineTo(nodes[j].x, nodes[j].y);
                    ctx.stroke();
                }
            }
        }

        nodes.forEach(node => node.draw());
    }

    document.getElementById('ntv-modeSelect').addEventListener('change', (e) => {
        isRunning = false;
        cancelAnimationFrame(animationId);
        document.getElementById('ntv-startBtn').innerText = 'Start Simulation';
        initSimulation(e.target.value);
    });

    document.getElementById('ntv-startBtn').addEventListener('click', () => {
        if (!isRunning && !nodes.every(n => n.progress === 100)) {
            isRunning = true;
            document.getElementById('ntv-startBtn').innerText = 'Running...';
            animate();
        }
    });

    document.getElementById('ntv-resetBtn').addEventListener('click', () => {
        isRunning = false;
        cancelAnimationFrame(animationId);
        document.getElementById('ntv-startBtn').innerText = 'Start Simulation';
        initSimulation(document.getElementById('ntv-modeSelect').value);
    });

    resize();
})();
</script>
{{< /rawhtml >}}

## Understanding the three models

The simulator above compares how the same file reaches many machines under three common patterns. Each blue dot is a chunk of data moving across the network; the progress ring on each node shows how much of the file it has received.

| Model | Topology | Who sends data? | Best for |
| --- | --- | --- | --- |
| **Direct** | 1-to-1 | One sender → one receiver | Small files, private transfers |
| **Client-Server** | Star (hub) | One central server → many clients | Websites, APIs, app updates from a CDN |
| **Torrent Swarm** | Mesh (P2P) | Any peer that already has data | Large files, many downloaders, limited server bandwidth |

Run each mode in the visualizer and notice how long it takes for every node to reach 100%. The torrent swarm finishes first because work is shared across the group instead of flowing through a single pipe.

## What is peer-to-peer (P2P)?

**Peer-to-peer (P2P)** is a network design where participants act as both **clients** (downloaders) and **servers** (uploaders). There is no single machine that must serve everyone.

In a P2P system:

- Every machine is a **peer** with equal standing in the network.
- A peer requests pieces it does not have from other peers that already hold them.
- As soon as a peer receives a piece, it can **upload that piece to others** — it becomes part of the distribution.

This is different from **client-server**, where clients only consume and the server does all the serving. P2P spreads bandwidth and load across the swarm.

## How BitTorrent-style swarms work

BitTorrent is the most widely known P2P file-distribution protocol. The simulation’s **Torrent Swarm** mode is a simplified view of how it behaves.

### 1. The file is split into pieces

Real torrents do not send one giant stream. The file is divided into fixed-size **pieces** (often 256 KB–4 MB each). Each piece has a hash so peers can verify it was received correctly. In the demo, each completed packet adds 5% progress — a stand-in for one piece arriving.

### 2. A torrent file or magnet link describes the swarm

A `.torrent` file or **magnet link** tells your client:

- The file name and total size
- Cryptographic hashes of every piece
- How to find other peers (**trackers**, DHT, or peer exchange)

Your client uses that metadata to join the swarm — it does not contain the file itself.

### 3. Seeders bootstrap the swarm

A **seeder** has the complete file (100% in the visualizer). The **Initial Seeder** in the center starts with everything; without at least one seeder (or a peer with full data), new joiners cannot finish.

### 4. Leechers download and immediately contribute

A **leecher** is still downloading (progress below 100%). In a healthy swarm, leechers are not passive — they upload pieces they already have to other leechers. That is why the mesh in the simulator shows many possible paths, not just lines to the center.

### 5. Swarm effect: more peers, more throughput

When Peer 1 gets data from the seeder, Peer 2 can get the same piece from Peer 1 *and* from the seeder. As more peers complete portions of the file, the number of upload sources grows. The central server model cannot do this — every client still depends on one bottleneck.

## Key P2P terms

| Term | Meaning |
| --- | --- |
| **Peer** | Any node in the swarm; may upload and download |
| **Seeder** | Peer with 100% of the file; keeps sharing after download |
| **Leecher** | Peer still downloading; uploads pieces it already has |
| **Piece** | A fixed chunk of the file; verified by hash |
| **Swarm** | All peers sharing a particular torrent at one time |
| **Tracker** | Server that helps peers find each other (optional with DHT) |
| **DHT** | Distributed hash table; peers find each other without a central tracker |

## P2P vs client-server: trade-offs

**Advantages of P2P**

- **Scales with popularity** — more downloaders can mean more upload capacity
- **No single bandwidth bill** — cost is shared across peers
- **Resilience** — no one server failure stops the swarm if seeders remain
- **Good for large files** — Linux ISOs, game patches, open-source media

**Disadvantages of P2P**

- **Upload depends on participants** — if everyone stops seeding, downloads stall
- **Harder to control** — no central point for access rules or auditing
- **Variable speed** — depends on peer count, their bandwidth, and ISP policies
- **Legal and policy concerns** — technology is neutral; usage must respect copyright and terms of service

**When client-server wins**

- Low-latency APIs and web pages
- Authenticated, per-user content
- Small files where P2P setup overhead is not worth it
- When you need guaranteed availability from your own infrastructure

## What the simulation is showing

- **Direct** — one link, one speed limit. Simple, but useless for distributing to a crowd.
- **Client-Server** — the server sends slowly to one random client at a time. All traffic crosses the center; it is the classic bottleneck.
- **Torrent Swarm** — any node with partial data can send to any incomplete peer, up to three packets per frame. The mesh lines show that any peer could talk to any other peer — that is the P2P idea.

Try switching modes without resetting, then hit **Reset** and run **Start Simulation** on each. Compare how quickly all nodes turn green (100%).

## Legitimate uses of P2P today

P2P is not only for file sharing. It powers or inspired many mainstream systems:

- **BitTorrent** — open-source software, Linux distributions, large dataset mirrors
- **Game launchers** — Blizzard, Riot, and others use P2P-style patching to reduce server load
- **IPFS / Web3 storage** — content-addressed blocks shared across nodes
- **Video conferencing** — WebRTC sends media directly between browsers when possible
- **Blockchain nodes** — each full node propagates blocks to peers

## Further reading

- [BitTorrent protocol specification (BEP 3)](http://www.bittorrent.org/beps/bep_0003.html) — original piece-based P2P design
- [WebRTC](https://webrtc.org/) — browser P2P for real-time communication
- [IPFS documentation](https://docs.ipfs.tech/) — peer-to-peer content storage and retrieval
