# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore
RUN dotnet publish -c release -o /app --no-restore
RUN ls /app

FROM build AS publish
RUN dotnet publish  -c Release -o /app/publish
RUN ls /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/dist .
COPY nginx.conf /etc/nginx/nginx.conf
RUN ls /usr/share/nginx/html

#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0
#WORKDIR /app
#COPY --from=build /app ./
#ENTRYPOINT ["dotnet", "aspnetapp.dll"]
