FROM maven:3.6.2-jdk-11-slim AS builder
WORKDIR /build
COPY pom.xml .
RUN mvn dependency:go-offline
COPY ./src ./src
RUN mvn clean package -Dmaven.test.skip=true

FROM openjdk:11.0.5-jre-slim-buster
COPY --from=builder /build/target/productos-0.0.1-SNAPSHOT.jar .
ENTRYPOINT java -Djava.net.preferIPv4Stack=true -jar ./productos-0.0.1-SNAPSHOT.jar
