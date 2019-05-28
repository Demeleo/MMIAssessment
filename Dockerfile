
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MMIAssess.API/*.csproj ./MMIAssess.API/
COPY MMIAssess.Core/*.csproj ./MMIAssess.Core/
COPY MMIAssess.Infrastructure/*.csproj ./MMIAssess.Infrastructure/
COPY MMIAssess.Tests/*.csproj ./MMIAssess.Tests/
RUN dotnet restore

# copy everything else and build app
COPY . .
COPY MMIAssess.API/. ./MMIAssess.API/
COPY MMIAssess.Core/. ./MMIAssess.Core/
COPY MMIAssess.Infrastructure/. ./MMIAssess.Infrastructure/
COPY MMIAssess.Tests/. ./MMIAssess.Tests/
WORKDIR /app
RUN dotnet publish -c Release -o /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MMIAssess.API.dll"]


