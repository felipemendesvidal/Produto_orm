#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Senai_Aula6/Senai_Aula6.csproj", "Senai_Aula6/"]
RUN dotnet restore "Senai_Aula6/Senai_Aula6.csproj"
COPY . .
WORKDIR "/src/Senai_Aula6"
RUN dotnet build "Senai_Aula6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Senai_Aula6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Senai_Aula6.dll"]