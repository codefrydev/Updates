---
title: "Organizational Chart"
author: "PrashantUnity"
weight: 115
date: 2025-09-15
lastmod: 2025-09-15
dateString: September 2025
description: "A simple Organizational chart using tailwind css"
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg" # image path/url
    alt: "Download Logo" # alt text
    #caption: "Optical Character Recognition"  display caption under cover 

tags: [ "Tailwind CSS", "Organisation Chart", "codefrydev", "CFD"]
keywords: [ "Tailwind CSS", "Organisation Chart", "codefrydev", "CFD"]
hideMeta: true
---

# Organizational Chart

A simple Organizational chart using tailwind css

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Modern Organizational Chart</title>
    <script src="https://cdn.tailwindcss.com"></script>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet">
    <style>
        :root {
            --color-blue: #6366f1;
            --color-teal: #2dd4bf;
            --color-orange: #fb923c;
            --color-pink: #f472b6;
            --color-sky: #38bdf8;
            --color-gray: #9ca3af;
            --color-indigo: #818cf8;
        }

        html, body {
            height: 100%;
            margin: 0;
            overflow: hidden; /* Prevents scrollbars on the body */
        }

        body {
            font-family: 'Inter', sans-serif;
            background-color: #f1f5f9;
            color: #1e293b;
            display: flex;
            flex-direction: column;
        }

        .page-wrapper { /* New class for the main container div */
            display: flex;
            flex-direction: column;
            flex-grow: 1; /* Allow this wrapper to grow and fill space */
            min-height: 0; /* Fix for flexbox overflow issue in some browsers */
        }

        .org-chart {
            display: flex;
            overflow: hidden;
            cursor: grab;
            user-select: none;
            background-color: #f8fafc;
            border-radius: 0.5rem;
            box-shadow: 0 4px 6px -1px rgb(0 0 0 / 0.1), 0 2px 4px -2px rgb(0 0 0 / 0.1);
            flex-grow: 1; /* Make the chart container fill available vertical space */
        }

        .org-chart ul {
            padding-top: 30px;
            position: relative;
            display: flex;
            justify-content: center;
        }

        .org-chart > ul {
            transform-origin: 0 0;
            transition: transform 0.2s ease-out;
        }

        .org-chart li {
            text-align: center;
            list-style-type: none;
            position: relative;
            padding: 30px 10px 0 10px;
            transition: all 0.5s;
        }

        /* --- New Node Styling --- */
        .node-wrapper {
            position: relative;
            display: inline-block;
        }
        
        .node-card {
            padding: 1rem 1.5rem;
            background-color: white;
            border-radius: 8px;
            display: inline-block;
            min-width: 160px;
            box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
            border-top: 4px solid;
            border-color: var(--node-color, var(--color-gray));
            transition: all 0.3s ease;
        }

        .node-image {
            width: 64px;
            height: 64px;
            border-radius: 50%;
            border: 4px solid;
            border-color: var(--node-color, var(--color-gray));
            background-color: white;
            position: absolute;
            top: 0;
            left: 50%;
            transform: translate(-50%, -50%);
            z-index: 1;
        }

        /* --- New Connecting Lines --- */
        /* Vertical line coming DOWN from parent node */
        .node-wrapper::after {
            content: '';
            position: absolute;
            bottom: -30px; /* should match li top padding */
            left: 50%;
            transform: translateX(-50%);
            width: 2px;
            height: 30px;
            background-color: #94a3b8;
        }
        
        /* Hide the downward line if node has no children or is collapsed */
        .node-wrapper.no-children::after,
        li.collapsed .node-wrapper::after {
            display: none;
        }

        /* Vertical line going UP from child node */
        .org-chart li::before {
            content: '';
            position: absolute;
            top: 0;
            left: 50%;
            transform: translateX(-50%);
            width: 2px;
            height: 30px;
            background-color: #94a3b8;
        }

        /* Horizontal line connecting all children */
        .org-chart li::after {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 2px;
            background-color: #94a3b8;
        }

        /* Remove lines for the root node */
        .org-chart > ul > li::before, .org-chart > ul > li::after {
            display: none;
        }

        /* Adjust horizontal line for first and last child */
        .org-chart li:first-child::after { left: 50%; width: 50%; }
        .org-chart li:last-child::after { width: 50%; }
        .org-chart li:only-child::after { display: none; }

        /* --- Collapsible styles --- */
        .org-chart li > ul { display: flex; }
        .org-chart li.collapsed > ul { display: none; }
        
        .toggle-btn {
            position: absolute;
            bottom: -10px;
            left: 50%;
            transform: translateX(-50%);
            width: 20px;
            height: 20px;
            background-color: white;
            color: #475569;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 14px;
            font-weight: bold;
            cursor: pointer;
            border: 1px solid #cbd5e1;
            user-select: none;
            transition: all 0.3s ease;
            z-index: 10;
        }
        .toggle-btn:hover { background-color: #f1f5f9; transform: translateX(-50%) scale(1.1); }
        
        /* --- Advisory Node --- */
        .advisory-node {
            position: absolute;
            top: 50%;
            left: 100%;
            transform: translateY(-50%);
            padding-left: 50px;
        }
        .advisory-connector {
            content: '';
            position: absolute;
            top: 50%;
            left: 100%;
            width: 50px;
            height: 2px;
            background: #94a3b8;
        }
        .root-node-wrapper {
            position: relative;
        }

    </style>
</head>
<body class="bg-gray-100">
        <main id="chart-container" class="org-chart">
            <!-- Chart will be generated here by JavaScript -->
        </main>

    <script>
        const orgData = {
            name: 'Mr. Anderson',
            role: 'Director',
            color: 'var(--color-blue)',
            imageUrl: 'https://placehold.co/100x100/6366f1/ffffff?text=MA',
            advisory: {
                name: 'Advisory Committee',
                role: 'Guidance & Oversight',
                color: 'var(--color-gray)',
                imageUrl: 'https://placehold.co/100x100/9ca3af/ffffff?text=AC'
            },
            children: [
                {
                    name: 'Mr. Robert',
                    role: 'Deputy Director',
                    color: 'var(--color-teal)',
                    imageUrl: 'https://placehold.co/100x100/2dd4bf/ffffff?text=MR',
                    children: [
                        {
                            name: 'Head of Education',
                            role: 'Team Lead',
                            color: 'var(--color-orange)',
                            imageUrl: 'https://placehold.co/100x100/fb923c/ffffff?text=HE',
                            children: [
                                { name: 'Lectures Team', role: 'Content Delivery', color: 'var(--color-orange)', imageUrl: 'https://placehold.co/100x100/fb923c/ffffff?text=LT', children: [
                                    { name: 'John Doe', role: 'Lecturer', color: 'var(--color-orange)', imageUrl: 'https://placehold.co/100x100/fb923c/ffffff?text=JD'},
                                    { name: 'Jane Smith', role: 'Lecturer', color: 'var(--color-orange)', imageUrl: 'https://placehold.co/100x100/fb923c/ffffff?text=JS'}
                                ]},
                                { name: 'Student Coordinators', role: 'Support', color: 'var(--color-orange)', imageUrl: 'https://placehold.co/100x100/fb923c/ffffff?text=SC', children: [
                                    { name: 'Peter Jones', role: 'Coordinator', color: 'var(--color-orange)', imageUrl: 'https://placehold.co/100x100/fb923c/ffffff?text=PJ'}
                                ]}
                            ]
                        },
                        {
                            name: 'Mark Davis',
                            role: 'Senior Manager',
                            color: 'var(--color-pink)',
                            imageUrl: 'https://placehold.co/100x100/f472b6/ffffff?text=MD',
                            children: [
                                { name: 'Accounting', role: 'Finance', color: 'var(--color-pink)', imageUrl: 'https://placehold.co/100x100/f472b6/ffffff?text=A', children: [
                                     { name: 'Alice Williams', role: 'Accountant', color: 'var(--color-pink)', imageUrl: 'https://placehold.co/100x100/f472b6/ffffff?text=AW' }
                                ]},
                                { name: 'Operational Staff', role: 'Execution', color: 'var(--color-pink)', imageUrl: 'https://placehold.co/100x100/f472b6/ffffff?text=OS', children: [
                                     { name: 'Bob Brown', role: 'Operator', color: 'var(--color-pink)', imageUrl: 'https://placehold.co/100x100/f472b6/ffffff?text=BB' },
                                     { name: 'Charlie Green', role: 'Operator', color: 'var(--color-pink)', imageUrl: 'https://placehold.co/100x100/f472b6/ffffff?text=CG' }
                                ]}
                            ]
                        },
                        {
                            name: 'Technicians',
                            role: 'Technical Support',
                            color: 'var(--color-sky)',
                            imageUrl: 'https://placehold.co/100x100/38bdf8/ffffff?text=T',
                            children: [
                               { name: 'Maintenance Staff', role: 'Infrastructure', color: 'var(--color-sky)', imageUrl: 'https://placehold.co/100x100/38bdf8/ffffff?text=MS', children: [
                                    { name: 'David White', role: 'Technician', color: 'var(--color-sky)', imageUrl: 'https://placehold.co/100x100/38bdf8/ffffff?text=DW' }
                               ]},
                               { name: 'IT Support', role: 'Helpdesk', color: 'var(--color-sky)', imageUrl: 'https://placehold.co/100x100/38bdf8/ffffff?text=IT' }
                            ]
                        },
                        {
                            name: 'Sarah Miller',
                            role: 'HR Manager',
                            color: 'var(--color-indigo)',
                            imageUrl: 'https://placehold.co/100x100/818cf8/ffffff?text=SM',
                            children: [
                                { name: 'Recruitment', role: 'Talent Acquisition', color: 'var(--color-indigo)', imageUrl: 'https://placehold.co/100x100/818cf8/ffffff?text=R' },
                                { name: 'Employee Relations', role: 'Internal Affairs', color: 'var(--color-indigo)', imageUrl: 'https://placehold.co/100x100/818cf8/ffffff?text=ER' }
                            ]
                        }
                    ]
                },
            ]
        };

        function createNode(person) {
            const li = document.createElement('li');
            
            const wrapper = document.createElement('div');
            wrapper.className = 'node-wrapper';
             if (!person.children || person.children.length === 0) {
                wrapper.classList.add('no-children');
            }

            const img = document.createElement('img');
            img.src = person.imageUrl;
            img.alt = `Profile picture of ${person.name}`;
            img.className = 'node-image object-cover';
            img.style.borderColor = person.color;

            const nodeDiv = document.createElement('div');
            nodeDiv.className = 'node-card';
            nodeDiv.style.borderColor = person.color;

            const nameDiv = document.createElement('div');
            nameDiv.className = 'font-bold text-slate-700 text-md pt-6';
            nameDiv.textContent = person.name;

            const roleDiv = document.createElement('div');
            roleDiv.className = 'text-sm text-slate-500';
            roleDiv.textContent = person.role;

            nodeDiv.appendChild(nameDiv);
            nodeDiv.appendChild(roleDiv);
            wrapper.appendChild(img);
            wrapper.appendChild(nodeDiv);
            
            if (person.children && person.children.length > 0) {
                const toggleBtn = document.createElement('span');
                toggleBtn.className = 'toggle-btn';
                toggleBtn.textContent = '−';
                wrapper.appendChild(toggleBtn);
                toggleBtn.addEventListener('click', (e) => {
                    e.stopPropagation();
                    const parentLi = e.target.closest('li');
                    parentLi.classList.toggle('collapsed');
                    e.target.textContent = parentLi.classList.contains('collapsed') ? '+' : '−';
                });
            }

            li.appendChild(wrapper);
            return li;
        }
        
        function createAdvisoryNode(person, parentWrapper) {
            const advisoryWrapper = document.createElement('div');
            advisoryWrapper.className = 'advisory-node';
            
            const nodeLi = createNode(person);
            // remove connector pseudo elements from this special node
            nodeLi.style.padding = 0;
            nodeLi.querySelector('.node-wrapper').classList.add('no-children');
            
            advisoryWrapper.appendChild(nodeLi);
            parentWrapper.appendChild(advisoryWrapper);
            
            const connector = document.createElement('div');
            connector.className = 'advisory-connector';
            parentWrapper.appendChild(connector);
        }

        function buildChart(person, parentElement, level = 0) {
            const node = createNode(person);
            parentElement.appendChild(node);
            
            // Add a wrapper for the root node to position advisory node correctly
            if(level === 0) {
                const rootWrapper = node.querySelector('.node-wrapper');
                rootWrapper.classList.add('root-node-wrapper');
                 if(person.advisory) {
                    createAdvisoryNode(person.advisory, rootWrapper);
                }
            }
            
            if (level >= 1) {
                node.classList.add('collapsed');
                const toggleBtn = node.querySelector('.toggle-btn');
                if (toggleBtn) toggleBtn.textContent = '+';
            }

            if (person.children && person.children.length > 0) {
                const childUl = document.createElement('ul');
                node.appendChild(childUl);
                person.children.forEach(child => buildChart(child, childUl, level + 1));
            }
        }
        
        const chartContainer = document.getElementById('chart-container');
        const rootUl = document.createElement('ul');
        chartContainer.appendChild(rootUl);
        buildChart(orgData, rootUl);

        // --- Pan and Zoom Logic ---
        const chart = chartContainer.querySelector('ul');
        let scale = 1;
        let panning = false;
        let pointX = 0;
        let pointY = 0;
        let start = { x: 0, y: 0 };

        function setTransform() {
            chart.style.transform = `translate(${pointX}px, ${pointY}px) scale(${scale})`;
        }

        window.addEventListener('load', () => {
            const containerWidth = chartContainer.offsetWidth;
            const chartWidth = chart.offsetWidth;
            pointX = (containerWidth - chartWidth) / 2;
            pointY = 50; // Add some initial top padding
            setTransform();
        });

        chartContainer.onmousedown = function (e) {
            if (e.target.closest('.toggle-btn, .node-card a')) return;
            e.preventDefault();
            panning = true;
            start = { x: e.clientX - pointX, y: e.clientY - pointY };
            chartContainer.style.cursor = 'grabbing';
        };

        chartContainer.onmouseup = function () {
            panning = false;
            chartContainer.style.cursor = 'grab';
        };
        
        chartContainer.onmouseleave = function () {
            panning = false;
            chartContainer.style.cursor = 'grab';
        };

        chartContainer.onmousemove = function (e) {
            if (!panning) return;
            e.preventDefault();
            pointX = e.clientX - start.x;
            pointY = e.clientY - start.y;
            setTransform();
        };

        chartContainer.onwheel = function (e) {
            e.preventDefault();
            const xs = (e.clientX - pointX) / scale;
            const ys = (e.clientY - pointY) / scale;
            const delta = (e.wheelDelta ? e.wheelDelta : -e.deltaY);
            (delta > 0) ? (scale *= 1.1) : (scale /= 1.1);
            scale = Math.max(0.3, Math.min(scale, 2)); // Clamp scale
            pointX = e.clientX - xs * scale;
            pointY = e.clientY - ys * scale;
            setTransform();
        };

    </script>
</body>
</html>

```
![Organisation Chart](./org-chart.png)