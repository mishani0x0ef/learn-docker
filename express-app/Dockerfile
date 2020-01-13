FROM node:latest

LABEL author="mishani0x0ef"

ENV PORT=3000

COPY . /app

WORKDIR /app

RUN npm install

EXPOSE ${PORT}

ENTRYPOINT [ "npm", "start" ]