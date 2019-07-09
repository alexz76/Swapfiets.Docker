# Docker Training

Welcome to Swapfiets Docker trainign!

## Sample Apps

### Node.js App with _**Docker CLI**_

Running a dummy app on Docker using Node.js image.

```sh
# Creates Docker running container of Node.js app on port `50000`
docker run -p 50000:3000 -v %cd%:/www/app -w "/www/app" node npm app.js
```

OR

```sh
# First run `install.sh` to install all node packages
install.sh

# Creates Docker running container of Node.js app on port `50001`
docker run -p 50001:3001 -v %cd%:/www/app -w "/www/app" node npm start
```

In the examples above, we're creating docker running containers using a node image, and it's all done through Docker CLI.

_**NOTE:** A better option would be using `Dockerfile` instead!_

### Node.js App with _**Dockerfile**_

**Dockerfile:**

```docker
FROM node:8-jessie as build
WORKDIR /src

COPY package.json .
RUN npm install

FROM build as runtime
ENTRYPOINT [ "npm", "start" ]
```

### SimpleWebApp Docker Image

```bash
# 'simplewebapp' image with version '1.0.0'
docker build -t simplewebapp:1.0.0 .
```

### SimpleWebApp Docker Container Spin up

```bash
# 'simpleweb-app' is the container name
# 'simplewebapp' is the image name and '1.0.0' is the image version
docker run --name simpleweb-app simplewebapp:1.0.0
```

---------------------------------------------------------------------------

### Python App

Funny name generator app.

**Dockerfile:**

```docker
FROM python:3 as build
WORKDIR /src
COPY . .

FROM build as final
ENTRYPOINT ["python", "Program.py"]
```

#### SwapNameGenerator Docker Image

```bash
# 'swapnamegen' image with version '0.0.1'
docker build -t swapnamegen:0.0.1 .
```

#### SwapNameGenerator Docker Container Spin up

```bash
# 'swapnamegen-app' is the container name
# 'swapnamegen' is the image name and '0.0.1' is the image version
docker run --name swapnamegen-app swapnamegen:0.0.1
```

After the container has been created, we can spin up it by its name or creting new containers as per code above, just changing the container name.

```bash
docker run swapnamegen-app -a
```

---------------------------------------------------------------------------

### Container Inspection

#### History

```bash
docker history {container-id} --no-trunc --format "{{.}}"
```

### Inspect

```bash
docker inspect {container(id/name)}
```
