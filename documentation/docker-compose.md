# docker-compose
docker compose is a tool that can help us easily handle multiple containers at once.  
in short, docker compose works by applying many rules in a single docker-compose.yml configuration file.

to start:
```sh
cd 'docker-compose.yml file location'
docker-compose up -d (d is to start in a detached mode)
```

to stop:
```sh
docker-compose down
```

in the docker-compose file we need to specifiy at least:
* version of the compose file format
* at least one service
* optioanlly: volumes and networks

```docker-compose.yml
version: "3.8"
services:
  ...
volumes:
  ...
networks:
  ...
```

## services
services refer to containers' configuration.

### pulling an Image
in case image we need has already been published in DockerHub or another docker registry
```docker-compose.yml
services:
  my-service:
    image: ubuntu:latest
    ...
```

### building an Image
instead, we might need to build an image from the source code by reading its Dockerfile
```docker-compose.yml
services:
  my-custom-app:
    build: /path/to/dockerfile
    ...
```

we can also use url instead of path
```docker-compose.yml
services:
  my-custom-app:
    build: https://github.com/my-org/my-proj.git
    ...
```
also we can name the image once created, making it available to be used by another services
```docker-compose.yml
services:
  my-custom-app:
    build: https://github.com/my-org/my-proj.git
    image: my-project-image
    ...
```

## volumes and networks
a volume is a shared directory in the host, visible from some or all containers  
networks define the communication rules between containers, and between a container and the host

https://www.baeldung.com/ops/docker-compose  -- continue