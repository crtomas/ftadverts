FROM microsoft/dotnet:2.2-sdk
WORKDIR /e2e

#restore
COPY e2e.csproj .
RUN dotnet restore 

COPY . .

ENV TEAMCITY_PROJECT_NAME=fake
ENTRYPOINT ["dotnet","test","-verbosity:normal"]