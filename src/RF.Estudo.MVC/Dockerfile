FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RF.Estudo.MVC/RF.Estudo.MVC.csproj", "RF.Estudo.MVC/"]
RUN dotnet restore "RF.Estudo.MVC/RF.Estudo.MVC.csproj"
COPY . .
WORKDIR "/src/RF.Estudo.MVC"
RUN dotnet build "RF.Estudo.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RF.Estudo.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RF.Estudo.MVC.dll"]
