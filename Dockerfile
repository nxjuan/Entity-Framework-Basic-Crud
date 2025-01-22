# Estabelecendo a imagem base (runtime) para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Estabelecendo a imagem para build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiando o arquivo do projeto (.csproj) e restaurando as dependências
COPY ["CrudDoYT.csproj", "./"]
RUN dotnet restore "./CrudDoYT.csproj"

# Copiando os demais arquivos do projeto
COPY . .

# Ajustando o diretório de trabalho para o local do .csproj
WORKDIR "/src"

# Build da aplicação
RUN dotnet build "./CrudDoYT.csproj" -c Release -o /app/build

# Publicando a aplicação
FROM build AS publish
RUN dotnet publish "./CrudDoYT.csproj" -c Release -o /app/publish

# Estabelecendo a imagem final (runtime)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Definindo o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "CrudDoYT.dll"]
