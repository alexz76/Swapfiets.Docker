# [Docker](https://docs.docker.com/)

- [Top 10 Docker Commands](https://hackernoon.com/top-10-docker-commands-you-cant-live-without-54fb6377f481)

## Docker CMD Helpers

### Delete All Containers

```bash
docker ps -a -q | ForEach { docker rm $_ --volumes --force }
```

### Delete All Images

```bash
docker images -a -q | ForEach { docker rmi $_ --force }
```

### Delete All Networks

```bash
docker network ls -q | ForEach { docker network rm $_ }
```

### Delete All Volumes

```bash
docker volume ls -q | ForEach { docker volume rm $_ --force }
```

### Run Ubuntu image with _volume_ and _bash scripts_

```bash
docker run -it -v %cd%/external/folder:/internal/folder ubuntu /bin/bash
```

-------------------------------------------------------

## Docker CLI

- [Docker Cheat-Sheet](https://github.com/wsargent/docker-cheat-sheet)

### Pull Images

Load an image from Docker image repository or other image source.

```bash
docker pull <image-name>
```

### Run Images

Run an image creating a container from the image.

```bash
docker run -d --name <container-name> -p 9000:9000 -p 9092:9092 <image-name>
```

### List Images

```bash
docker images [--all]
```

*or* `docker image ls [--all]`

### List Containers

```bash
docker container ls [--all]
```

### Remove Images

```bash
docker image rm <[image-id]|[image-name]>
```

*or* `docker rmi <[image-id]|[image-name]>`

### Remove Containers

```bash
docker container rm <[container-id]|[container-name]>
```

*or* `docker rm <[container-id]|[container-name]>`

### Exec in Container

#### Run `BASH` in Container

```bash
docker exec -it {Container-ID} bash
```

-------------------------------------------------------

## Docker-Compose CLI

- [Docker Compose Overview](https://docs.docker.com/compose/overview/)

### Build App Project

```bash
docker-compose build
```

> Run command from the Docker project root folder

### Run App Project

```bash
docker-compose up
```

-------------------------------------------------------

## Docker Reference

- [Dockerfile Reference](https://docs.docker.com/engine/reference/builder/)
- [Docker for ASP.NET Core](https://docs.microsoft.com/en-gb/aspnet/core/host-and-deploy/docker/visual-studio-tools-for-docker?view=aspnetcore-2.1)

### [Usage](https://docs.docker.com/engine/reference/builder/#usage)

> The Docker daemon runs the instructions in the Dockerfile one-by-one, committing the result of each instruction to a new image if necessary, before finally outputting the ID of your new image. The Docker daemon will automatically clean up the context you sent.

- [Parser directives](https://docs.docker.com/engine/reference/builder/#parser-directives)
- [Escape](https://docs.docker.com/engine/reference/builder/#escape)

### [Environment replacement](https://docs.docker.com/engine/reference/builder/#environment-replacement)

Valid variables are `${variable_name}` or `$variable_name`.

#### Setting an environment variable

```:
FROM Image:Version
ENV SomeVar ItsValue
RUN "Variable Value: ${SomeVar}"
```

### [.dockerignore](https://docs.docker.com/engine/reference/builder/#dockerignore-file)

### [FROM](https://docs.docker.com/engine/reference/builder/#from)

The `FROM` instruction initializes a new build stage and sets the Base Image for subsequent instructions.

> A Dockerfile **must start with a `FROM` instruction**.

**Samples:**

```docker
FROM <image> [AS <name>]
```

or

```docker
FROM <image>[:<tag>] [AS <name>]
```

or

```docker
FROM <image>[@<digest>] [AS <name>]
```

### [RUN](https://docs.docker.com/engine/reference/builder/#run)

**`RUN`** has 2 forms:

**shell form:**

```docker
RUN <command>
```

The command is run in a shell, which by default is /bin/sh -c on Linux or cmd /S /C on Windows.

**exec form:**

```docker
RUN ["executable", "param1", "param2"]
```

### [CMD](https://docs.docker.com/engine/reference/builder/#cmd)

The **`CMD`** instruction has three forms:

```docker
CMD ["executable","param1","param2"]  // exec form, this is the preferred form
CMD ["param1","param2"]               // as default parameters to `ENTRYPOINT`
CMD command param1 param2             // shell form
```

> There **can only be one `CMD` instruction** in a Dockerfile or per build session (`FROM`). If you list more than one `CMD` then only the last `CMD` will take effect.

### [LABEL](https://docs.docker.com/engine/reference/builder/#label)

### [EXPOSE](https://docs.docker.com/engine/reference/builder/#expose)

### [ENV](https://docs.docker.com/engine/reference/builder/#env)

### [ADD](https://docs.docker.com/engine/reference/builder/#add)

> The `ADD` instruction copies new files, directories or remote file URLs from **`<src>`** and adds them to the filesystem of the image at the path **`<dest>`**.

**`ADD`** has two forms:

```docker
ADD [--chown=<user>:<group>] <src>... <dest>
```

or

```docker
ADD [--chown=<user>:<group>] ["<src>",... "<dest>"]
```

This form is required for paths containing whitespace

### [COPY](https://docs.docker.com/engine/reference/builder/#copy)

### [ENTRYPOINT](https://docs.docker.com/engine/reference/builder/#entrypoint)

### [VOLUME](https://docs.docker.com/engine/reference/builder/#volume)

### [USER](https://docs.docker.com/engine/reference/builder/#user)

### [WORKDIR](https://docs.docker.com/engine/reference/builder/#workdir)

> The **`WORKDIR`** instruction sets the working directory for any `RUN`, `CMD`, `ENTRYPOINT`, `COPY` and `ADD` instructions that follow it in the Dockerfile. If the `WORKDIR` doesn’t exist, it will be created even if it’s not used in any subsequent Dockerfile instruction.

**Samples:**

```docker
WORKDIR /a
WORKDIR b
WORKDIR c
RUN pwd // output /a/b/c
```

### [ARG](https://docs.docker.com/engine/reference/builder/#arg)

```docker
ARG <name>[=<default value>]
```

> The **`ARG`** instruction defines a variable that users can pass at build-time to the builder with the docker build command using the **`--build-arg <varname>=<value>`** flag. If a user specifies a build argument that was not defined in the Dockerfile, the build outputs a warning.

### [ONBUILD](https://docs.docker.com/engine/reference/builder/#onbuild)

### [STOPSIGNAL](https://docs.docker.com/engine/reference/builder/#stopsignal)

### [HEALTHCHECK](https://docs.docker.com/engine/reference/builder/#healthcheck)

The `HEALTHCHECK` instruction has two forms:

**Check container health by running a command inside the container:**

```docker
HEALTHCHECK [OPTIONS] CMD command
```

**Disable any *healthcheck* inherited from the base image**

```docker
HEALTHCHECK NONE
```

> The **`HEALTHCHECK`** instruction tells Docker how to test a container to check that it is still working. This can detect cases such as a web server that is stuck in an infinite loop and unable to handle new connections, even though the server process is still running.

### [SHELL](https://docs.docker.com/engine/reference/builder/#shell)

-------------------------------------------------------

## Docker Compose Reference

- [Docker Compose File Reference](https://docs.docker.com/compose/compose-file/)
- [Docker Compose Networking](https://runnable.com/docker/docker-compose-networking)
