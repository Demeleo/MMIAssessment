#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MMIAssess.API.csproj", "MMIAssess.API/"]
COPY *.sln .
COPY MMIAssessment/*.csproj ./MMIAssessment/
RUN dotnet restore

# copy everything else and build app
COPY MMIAssessment/. ./MMIAssessment/
WORKDIR /app/MMIAssessment
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MMIAssess.API.dll"]
#
#FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
#WORKDIR /app
#
## copy csproj and restore as distinct layers
#COPY *.sln .
#COPY aspnetapp/*.csproj ./aspnetapp/
#RUN dotnet restore
#
## copy everything else and build app
#COPY aspnetapp/. ./aspnetapp/
#WORKDIR /app/aspnetapp
#RUN dotnet publish -c Release -o out
#
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
#WORKDIR /app
#COPY --from=build /app/aspnetapp/out ./
#ENTRYPOINT ["dotnet", "aspnetapp.dll"]