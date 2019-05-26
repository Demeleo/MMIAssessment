# #Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
# #For more information, please see https://aka.ms/containercompat
# #
# FROM microsoft/dotnet:aspnetcore-runtime AS base
# WORKDIR /app

# FROM microsoft/dotnet:sdk AS build
# WORKDIR /src
# COPY ["./MMIAssess.API/MMIAssess.API.csproj", "MMIAssess.API/"]

# RUN dotnet restore "./MMIAssess.API/MMIAssess.API.csproj"
# COPY ./MMIAssess.API/ ./
# WORKDIR "/src/MMIAssess.API"
# RUN dotnet build "MMIAssess.API.csproj" -c Release -o /app

# FROM build AS publish
# RUN dotnet publish "MMIAssess.API.csproj" -c Release -o /app

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app .
# ENTRYPOINT ["dotnet", "MMIAssess.API.dll"]

# # FROM microsoft/dotnet:sdk AS build-env
# # WORKDIR /app

# # # Copy everything else and build
# # COPY ./MMIAssess.API/ ./MMIAssess.API/
# # COPY ./MMIAssess.Core/ ./MMIAssess.Core/
# # COPY ./MMIAssess.Infrastructure/ ./MMIAssess.Infrastructure/
# # COPY ./MMIAssess.sln ./
# # RUN dotnet restore
# # RUN dotnet publish -c Release -o out

# # # Build runtime image
# # FROM microsoft/dotnet:aspnetcore-runtime
# # WORKDIR /app
# # COPY --from=build-env /app/out .
# # ENTRYPOINT ["dotnet", "aspnetapp.dll"]

FROM microsoft/aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:sdk AS build
WORKDIR /src
COPY MMIAssess.sln ./

RUN dotnet restore

COPY . .
WORKDIR /src/MMIAssess.API
RUN dotnet build -c Release -o /app

WORKDIR /src/MMIAssess.Core
RUN dotnet build -c Release -o /app

WORKDIR /src/MMIAssess.Infrastructure
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MMIAssess.API.dll"]
