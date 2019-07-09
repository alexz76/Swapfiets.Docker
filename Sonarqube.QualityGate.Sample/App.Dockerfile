# Arguments
ARG DOTNET_VERSION=2.1-aspnetcore-runtime
ARG DOTNETSDK_VERSION=2.1-sdk

# # AspNetCore Runtime
# FROM microsoft/dotnet:${DOTNET_VERSION} AS runtime
# WORKDIR /app
# COPY . /app

# AspNetCore SDK
FROM microsoft/dotnet:${DOTNETSDK_VERSION} AS sdk
WORKDIR /src

ARG sonartoken
ARG projectkey
ARG solution
RUN echo "Solution Name: ${solution}"

# SonarScanner
RUN dotnet tool install dotnet-sonarscanner --tool-path . --version 4.3.1

COPY . /src

RUN ./dotnet-sonarscanner begin /k:"${projectkey}" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="${sonartoken}"
RUN dotnet build ${solution}
RUN ./dotnet-sonarscanner end /d:sonar.login="${sonartoken}"