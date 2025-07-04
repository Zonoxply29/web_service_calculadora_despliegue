# Usar la imagen base del SDK de .NET para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solo el archivo .csproj y restaurar dependencias (para aprovechar la caché de Docker)
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos del proyecto
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Usar la imagen base de ASP.NET para el runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos compilados y publicados desde la etapa de construcción
COPY --from=build /app/publish .

# Definir variables de entorno para la producción
ENV ASPNETCORE_ENVIRONMENT=Production
ENV PORT=5000

# Exponer el puerto de la aplicación (opcional, pero útil para el acceso al contenedor)
EXPOSE 5000

# Iniciar la aplicación
ENTRYPOINT ["dotnet", "web_service_calculadora_despliegue.dll"]
