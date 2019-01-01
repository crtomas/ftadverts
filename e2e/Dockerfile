FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /e2e

#restore
COPY e2e.csproj .
RUN dotnet restore 

COPY . .

#publish
RUN dotnet publish e2e.csproj -o /publish

# Runtime stage
FROM microsoft/dotnet:2.2-runtime
COPY --from=build-env /publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet","test"]