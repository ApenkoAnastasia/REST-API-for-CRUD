# REST APIs for CRUD operations in ASP.NET Core using the MySQL database. 
## Description
In this description, I tell how to create a containerized ASP.NET Core 2.2 Web API project (web application, based on .NET Core with MySQL database and deploy using Docker-Compose.). 

## How to use it?
1. clone this project 'git clone https://github.com/yanshengjie/Docker.NetCore.MySql.git' 
2. go to 'cd Docker-compose-dotnet-core-and-mysql'
3. if you want to see this application running, you can type 'docker-compose up' from the solution directory.
### Checking system
4. If you want to see if this system works properly, access your browser following GET address - 'http://localhost:8080/all' and you should see the following results taken from the database:

``` json
[
  {
    "id":1,
    "name":"Dependency Injection Principles, Practices, and Patterns",
    "description":"Book by Steven van Deursen and Mark Seemann"
  },
  {
    "id":2,
    "name":"The Green Mile",
    "description":"Book by Stephen King"
    },
  {
    "id":3,
    "name":"Pride and Prejudice",
    "description":"Book by Jane Austen"
  },
  {
    "id":4,
    "name":"The Inimitable Jeeves",
    "description":"Book by P.G. Wodehouse"
    },
  {
    "id":5,
    "name":"Agile Software Development, Principles, Patterns, and Practices",
    "description":"Book by Robert C. Martin"
    }
]
```
## Using Postman (to see the APIs)
Following are the APIs we created:

1. 'GET http://localhost:8080/all' (To get all products)
2. 'POST http://localhost:8080/create' (To create a new product)
3. 'GET http://localhost:8080/{id}' (To get a specific product)
4. 'POST http://localhost:8080/delete/{id}' (To delete a specific product)
5. 'POST http://localhost:8080/modify/{id}' (To update a specific product)
So, we have created REST APIs for CRUD operations successfully in ASP.NET Core using the MySQL database. 

When you want to clean up containers and networks created by docker-compose, just type 'docker-compose down' from the solution directory.