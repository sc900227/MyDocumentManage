FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 6000/tcp
ENV ASPNETCORE_URLS http://*:6000
ENTRYPOINT ["dotnet", "run"]