FROM node:8-jessie as build
WORKDIR /src

COPY package.json .
RUN npm install

FROM build as runtime
ENTRYPOINT [ "npm", "start" ]