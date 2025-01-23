# Estágio 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar os arquivos do projeto
COPY ["CrudDoYT.csproj", "./"]
RUN dotnet restore "CrudDoYT.csproj"

# Copiar todo o código e realizar o build
COPY . .
RUN dotnet publish "CrudDoYT.csproj" -c Release -o /app/publish

# Estágio 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CrudDoYT.dll"]
