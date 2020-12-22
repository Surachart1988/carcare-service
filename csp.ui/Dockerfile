# develop stage
FROM node:12.19.0-alpine3.10 as develop-stage
RUN apk add --no-cache automake autoconf libtool alpine-sdk nasm
WORKDIR /app
COPY package*.json ./
RUN yarn install
COPY . .

# build stage
FROM develop-stage as build-stage
RUN yarn build

# production stage
FROM nginx:latest as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]