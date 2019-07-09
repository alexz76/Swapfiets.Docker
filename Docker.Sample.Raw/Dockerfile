# escape=`

# Arguments
ARG DOTNET_VERSION=2.1-aspnetcore-runtime
ARG SONAR_VERSION=6.7.4

# AspNetCore Runtime
FROM microsoft/dotnet:${DOTNET_VERSION} AS base
WORKDIR /app
COPY *.md /app/
RUN dir ./

# Sonarqube
FROM sonarqube:${SONAR_VERSION} AS sonar
WORKDIR /sonar
COPY *file /sonar/
RUN dir ./

# Sonarqube SDK
# TODO : Download SDK

# Arguments
ARG sonartoken=undefined
RUN echo "Argument: $sonartoken"

# Environment Variables
ENV ASPNETCORE_ENVIRONMENT Development
RUN echo "Environment: ${ASPNETCORE_ENVIRONMENT}"