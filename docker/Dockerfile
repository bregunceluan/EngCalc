# Define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY ./src ./src
COPY ./tests ./tests

# Restaura os pacotes NuGet
WORKDIR /app/src/engcalc.api
RUN dotnet restore

# Compila a api
RUN dotnet publish -c Release -o /app/publish

# Define o runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build /app/publish .

# Expõe a porta da API
EXPOSE 8080

# Define o ponto de entrada
ENTRYPOINT ["dotnet", "engcalc.api.dll"]