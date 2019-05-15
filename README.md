# dotnet-webapi-example
ASP.NET Core API Server that uses MongoDB in the backend

### Requirement
----------------
+ Using Docker & Docker Compose
+ NET CORE SDK 2.2
+ ASPNET RUNTIME 2.2
+ MongoDB


### Usage
----------

Build image
```
cd backend
docker build --pull -t aspnetwebapi .
```

Run image
```
docker run --name webapp --rm -it -p 5000:80 aspnetwebapi
```

Check api
```
Method GET http://localhost:5000/api/products
```

### Reference
--------------
+ [Example AspNetCore](https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/web-api/index/samples/2.x)
+ [Docker+ MongoDB + .NETCore](https://medium.com/@kristaps.strals/docker-mongodb-net-core-a-good-time-e21f1acb4b7b)
