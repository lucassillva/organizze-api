# Organizze API

TODO

### PostgreSQL

Para subir o BD local, o recomendado é utilizar o Docker e executar o seguinte comando:

``` shell
docker run --rm --name pg-docker -e POSTGRES_PASSWORD=docker -d -p 5432:5432 postgres
```

Caso seja necessário derrubar o BD, basta executar:

``` shell
docker container kill pg-docker
```