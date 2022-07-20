FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-stage

FROM build-stage AS build

COPY . .

# Build the project
RUN dotnet restore 
RUN dotnet publish -c Release -o /app
#-----------------------------------------------------------------------------

FROM build-stage as final
WORKDIR /app
COPY --from=build /app .
CMD dotnet test Test.UI.dll --logger:trx;
