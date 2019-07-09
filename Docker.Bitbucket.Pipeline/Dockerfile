# Arguments
ARG DOTNET_VERSION=sdk

# AspNetCore Runtime
FROM microsoft/dotnet:${DOTNET_VERSION} AS base
WORKDIR /app
COPY . .

# Install OpenJDK-8
RUN apt-get update && \
    apt-get install -y openjdk-8-jdk && \
    apt-get install -y ant && \
    apt-get clean;

# Fix certificate issues
RUN apt-get update && \
    apt-get install ca-certificates-java && \
    apt-get clean && \
    update-ca-certificates -f;

# Setup JAVA_HOME -- useful for docker commandline
ENV JAVA_HOME /usr/lib/jvm/java-8-openjdk-amd64/
RUN export JAVA_HOME

# Variables
ENV SONAR_ORGANIZATION="higtrollers-bitbucket"
ENV SONAR_URL="https://sonarcloud.io"
ENV SONAR_TOKEN="8395c4e299b8ff35f286d2eb8188baa62d83df5a"

# Scripts
RUN dotnet restore
RUN dotnet tool install dotnet-sonarscanner --tool-path . --version 4.3.1
RUN ./dotnet-sonarscanner begin /key:"sonarqube.qualitygate.api" /d:sonar.organization="higtrollers-bitbucket" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login=$SONAR_TOKEN
RUN dotnet build --no-restore
RUN ./dotnet-sonarscanner end /d:sonar.login=$SONAR_TOKEN