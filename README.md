# aspCoreApi
ASP.NET Core API with Docker and SQL Server

docker build -t test/commanderapi .
docker run -p 8080:80 test/commanderapi

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=quentin' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu

docker-compose up --build

url : localhost:8080/api/commander

