FROM python:3 as build
WORKDIR /src
ARG SomeSecret=ThisIsMySecretNotAsSecretAsIImagined

COPY . .

FROM build as final
ENTRYPOINT [ "python", "Program.py" ]