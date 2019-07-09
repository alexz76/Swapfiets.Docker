FROM bonomat/nodejs-hello-world:latest

MAINTAINER Alexandre Souza, alexandre-souza.com

COPY . /var/www
# WORKDIR /var/www

ENV NODE_ENV=Production
ENV PORT=3000

RUN ls
RUN ls /var/www
RUN npm install

# WORKDIR ./
ENTRYPOINT ["npm", "start"]