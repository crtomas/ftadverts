FROM microsoft/dotnet:2.2-sdk
WORKDIR /e2e

#restore
COPY e2e.csproj .
RUN dotnet restore 

COPY . .

ENTRYPOINT ["dotnet","test","--verbosity normal"]