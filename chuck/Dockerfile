# Build
FROM node:current-alpine3.13 as node
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Serve
FROM nginx:1.21.3-alpine
COPY --from=node /usr/src/app/dist/chuck /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf