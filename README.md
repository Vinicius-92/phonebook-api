[![My Linkedin Profile](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](http://www.linkedin.com/in/vinicius-92)

## Person control REST API 

### A full CRUD API for a model/entity person
A fully functional API that control person and their list of phone numbers. Made using:

* .NET 3.1.4
* EF Core
* AutoMapper
* Pomelo MySql

## Endpoints:

GET - List all persons in database:
```
/api
```

GET - Fecth a person by ID:
```
/api/{id}
```

DELETE - Delete person by ID:
```
/api/{id}
```

POST - Create person:
```
/api
```

JSON required in body:
```json
{
    "name": "example",
    "lastName": "lastExample",
    "cpf": "stringcpf",
    "birthDate": "yyyy-MM-ddT00:00:00.000000Z"
}
``` 

POST - Add phone number to person:
```
/api/{id}
```


JSON required in body:
```json
{
     "phoneType": 1,
    "number": "99635-9084"
}
```

### Phone types:

* Home = 0
* Cellphone = 1
* Commercial = 2

### TODO
* Create a seeding service to auto create registers in the database
