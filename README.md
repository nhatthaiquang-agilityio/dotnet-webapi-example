# dotnet-webapi-example
+ Using Docker
+ NET CORE SDK 2.2
+ ASPNET RUNTIME 2.2

### Usage

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
+ [Example AspNetCore](https://github.com/aspnet/AspNetCore.Docs/blob/master/aspnetcore/web-api/index/samples/2.x)
