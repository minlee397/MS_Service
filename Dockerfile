FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["QL_DT.csproj", "./"]
RUN dotnet restore "./QL_DT.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "QL_DT.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "QL_DT.csproj" -c Release -o /app

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT development
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QL_DT.dll"]
