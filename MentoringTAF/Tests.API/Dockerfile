FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-stage

FROM build-stage AS build

COPY . .

# Build the project
RUN dotnet restore
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

#-----------------------------------------------------------------------------

FROM build-stage as final
WORKDIR /app
COPY --from=build /app/build .
CMD dotnet test Tests.API.dll --logger:trx;
CMD sleep 300