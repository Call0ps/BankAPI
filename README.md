# Bank API

### Description
A WebAPI to manage a bank account. To be expanded. 
URL: https://projectbankportfolio.azurewebsites.net/

# Endpoints

```http
GET /api/HelloWorld
```
A simple endpoint, returns "Hello World"

---
## User
### Get
```http
GET /api/UserAccount
```
Returns a user if an id is specified, otherwise a list of all users.
### Post
```http
POST /api/UserAccount
```
Create a user using the following schema in the body.
``` json
{
  "id": 0,
  "email": "string"
}
```
### Delete
``` http
DELETE /api/UserAccount?id=<id>
```
Delete a user by id 

### Put
```http
PUT /api/UserAccount?id=<id>&newMail=<mail>
```
Update the mail address of a user.

---
