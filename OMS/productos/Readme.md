# Product Service for PICA Project

This section manage product service for PICA project in the Toures Balon company 

This section is done with Java - Spring Boot - Postgres - Docker

# Commands

docker pull postgres:12.0
docker run --name postgres -p 5432:5432 -e POSTGRES_PASSWORD=javeriana123 -d postgres:12.0

Log in container
docker exec -it -u 0 postgres bash

create database product;
GRANT ALL PRIVILEGES ON DATABASE product TO postgres;

spring.jpa.database=POSTGRESQL
spring.datasource.platform=postgres
spring.datasource.url=jdbc:postgresql://localhost:5432/product
spring.datasource.username=postgres
spring.datasource.password=javeriana123
spring.jpa.show-sql=true
spring.jpa.generate-ddl=true
spring.jpa.hibernate.ddl-auto=create
spring.jpa.properties.hibernate.jdbc.lob.non_contextual_creation=true



# Documentation

### Reference Documentation
For further reference, please consider the following sections:

* [Spring Data JPA @Query](https://www.baeldung.com/spring-data-jpa-query)

### Guides

The following guides illustrate how to use some features concretely:

* [Building a RESTful Web Service](https://spring.io/guides/gs/rest-service/)
* [Serving Web Content with Spring MVC](https://spring.io/guides/gs/serving-web-content/)
* [Building REST services with Spring](https://spring.io/guides/tutorials/bookmarks/)
* [Accessing Data with JPA](https://spring.io/guides/gs/accessing-data-jpa/)

