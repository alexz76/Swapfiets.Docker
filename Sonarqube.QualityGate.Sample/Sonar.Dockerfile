# Arguments
ARG SONAR_VERSION=6.7.4

# Sonarqube
FROM sonarqube:${SONAR_VERSION} AS sonar
EXPOSE 9000