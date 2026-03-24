---
title: "Postgres 16 in Docker"
author: "PrashantUnity"
weight: 103
date: 2026-03-24
lastmod: 2026-03-24
dateString: March 2026  
description: "Compose file, volume, connect, and cleanup."
#canonicalURL: "https://canonical.url/to/page"
cover:
    image: "cover.jpg"
    alt: "PostgreSQL database" # alt text
    #caption: "PostgreSQL on Docker"  display caption under cover

tags: [ "PostgreSQL", "Docker", "Docker Compose", "database", "development", "codefrydev" ]
keywords: [ "PostgreSQL", "Docker", "Docker Compose", "postgres", "container", "codefrydev", "CFD", "local development" ]
---
## Overview

This guide shows how to run [PostgreSQL](https://www.postgresql.org/) 16 locally using the official Docker image and Docker Compose. You get a default database user and database, port `5432` on your machine mapped into the container, and a **named volume** so data survives container restarts.

## Prerequisites

- **Docker Engine** installed ([Get Docker](https://docs.docker.com/get-docker/)).
- **Docker Compose** v2 (bundled with Docker Desktop; on Linux you may use the `docker compose` plugin).

The `version:` key at the top of a Compose file is optional in modern Compose; including `version: '3.8'` is still fine for compatibility.

## Create `docker-compose.yml`

Create a file named `docker-compose.yml` in your project directory:

```yaml
version: '3.8'

services:
  # Database service
  db:
    image: postgres:16
    container_name: postgres_db
    restart: always

    environment:
      POSTGRES_USER: my_user
      POSTGRES_PASSWORD: my_super_secret_password
      POSTGRES_DB: my_database

    ports:
      - "5432:5432"

    volumes:
      - postgres_data:/var/lib/postgresql/data

volumes:
  postgres_data:
```

What this does:

- **`image: postgres:16`** — Official PostgreSQL 16 image.
- **`restart: always`** — Restarts the container if it exits or after a host reboot (when Docker starts).
- **`environment`** — Creates the default role and database on first run.
- **`ports`** — Maps host `5432` to the container. If something else already uses `5432` on your machine, change the left side (e.g. `"5433:5432"`) and connect to that host port instead.
- **`volumes`** — `postgres_data` is a Docker named volume; it stores data at `/var/lib/postgresql/data` **inside** the container (the correct path for the official image).

**Security:** For real projects, avoid committing real passwords in shared repositories. Prefer environment files (e.g. `.env` not committed) with `env_file:` or your orchestrator’s secrets, and use strong passwords.

## Run and verify

From the directory that contains `docker-compose.yml`:

```bash
docker compose up -d
docker compose ps
```

Check logs if needed:

```bash
docker logs postgres_db
```

You should see PostgreSQL ready to accept connections once startup finishes.

## Connect

From the host, using the same user, password, database, and **host port** you configured (default `5432`):

```bash
psql "postgresql://my_user:my_super_secret_password@localhost:5432/my_database"
```

### DBeaver

1. Open **DBeaver** and choose **Database → New Database Connection** (or click **New Connection** in the toolbar).
2. Select **PostgreSQL** and click **Next**.
3. On the **Main** tab, set:
   - **Host:** `localhost`
   - **Port:** `5432` (or the host port you mapped in `docker-compose.yml`, e.g. `5433` if you used `"5433:5432"`)
   - **Database:** `my_database`
   - **Username:** `my_user`
   - **Password:** `my_super_secret_password` (check **Save password** if you want it stored locally)
4. Click **Test Connection**. If prompted, let DBeaver **download** the PostgreSQL JDBC driver the first time.
5. Click **Finish** to save the connection.

For a typical local Docker setup, leave **SSL** off (or **disable**) on the **SSL** tab unless you have configured TLS yourself.

### Other GUI tools

Use the same values as above:

- **Host:** `localhost`
- **Port:** `5432` (or the host port you mapped)
- **Database:** `my_database`
- **User / password:** as in `POSTGRES_USER` / `POSTGRES_PASSWORD`

Connection URI form:

```text
postgresql://my_user:my_super_secret_password@localhost:5432/my_database
```

## Useful commands

Stop containers (keeps the named volume and data):

```bash
docker compose stop
```

Stop and remove containers (volume **still** keeps data unless you remove it):

```bash
docker compose down
```

Remove the named volume and **delete persisted data** (use only when you intend to wipe the database):

```bash
docker compose down -v
```

List volumes:

```bash
docker volume ls
```

## Summary

You now have PostgreSQL 16 running in Docker with persistent storage via `postgres_data`, accessible on `localhost` at the mapped port. Adjust credentials and ports for your environment, and keep secrets out of version control for anything beyond local experimentation.
