# Build stage
FROM microsoft/dotnet:2.2-sdk AS build-env

WORKDIR /ftadverts

#restore
COPY api/api.csproj ./api/
RUN dotnet restore api/api.csproj

COPY tests/tests.csproj ./tests/
RUN dotnet restore tests/tests.csproj

#Uncomment to inspect what files are being copied in
#RUN ls -alR

#copy src
COPY . .

#test
ENV TEAMCITY_PROJECT_NAME=fake
RUN dotnet test tests/tests.csproj --verbosity normal

#publish
RUN dotnet publish api/api.csproj -o /publish

# Runtime stage
FROM microsoft/dotnet:2.2-aspnetcore-runtime
COPY --from=build-env /publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet","api.dll"]

#docker build -t apiprod .
#docker run --rm -p 8080:80 -d apiprod
#http://192.168.99.100:8080
