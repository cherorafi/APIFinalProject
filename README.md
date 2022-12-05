# APIFinalProject
This is an API that can do CRUD operations on a database consisting of 2 tables Accounts and Players.
I deleted some columns from the tables to limit the number of endpoints that I had in the initial presentation

## All Endpoints

**Account Table All Methods:**

**Method** | **Endpoint** | **Description**
--- | --- | ---
GET | `api/Account` | Get all accounts
GET | `api/Account/{username}` | Get a single account from given username
GET | `api/Account/violations` | Get all accounts that have violations
GET | `api/Account/player/{id}` | Get the account assiocated with the given player id
PUT | `api/Account/{username}` | Update an existing account with given info
PATCH | `api/Account/violations/{username}` | Update only the violations of a given user
POST | `api/Account` | Create a new account with given info
DELETE | `api/Account/{username}` | Delete an account if they have no existing players

**Player Table All Methods:**

**Method** | **Endpoint** | **Description**
--- | --- | ---
GET | `api/Player` | Get all players
GET | `api/Player/{id}` | Get a single player from given player id
GET | `api/Player/username/{username}` | Get all players belonging to an account from given username
GET | `api/Player/location/{last_location}` | Get all players who share the same location
GET | `api/Player/level/{player_level}` | Get all players who are the given level
GET | `api/Player/name/{name}` | Get all players who have the given name
PUT | `api/Player/{id}` | Update an existing player with given info
PATCH | `api/Player/level/{id}` | Update only the level of a given player
PATCH | `api/Player/name/{id}` | Update only the name of a given player
PATCH | `api/Player/location/{id}` | Update only the location of a given player
POST | `api/Player` | Create a new player with given info
DELETE | `api/Player/{id}` | Delete a player with id

## Account Table Samples

### GET - `api/Account`
Response:
``` 
[
    {
        "username": "amberloo",
        "number_of_characters": 1,
        "violations": false
    },
    {
        "username": "c2004",
        "number_of_characters": 1,
        "violations": false
    },
]
```
I only took the first two entries to shorten the sample

### GET - `api/Account/{username}`
#### Sucessful endpoint - `api/Account/amberloo`
Response:
```
{
        "username": "amberloo",
        "number_of_characters": 1,
        "violations": false
}
```

### PUT - `api/Account/{username}`
#### Sucessful endpoint - `api/Account/amberloo`
Body:
```
{
        "username": "amberloo",
        "number_of_characters": 2,
        "violations": true
}
```
Response:
```
{
    "statusCode": 200,
    "statusDescription": "Updated account info",
    "recieved": null
}
```

### PATCH - `api/Account/violations/{username}`
#### Sucessful endpoint - `api/Account/violations/amberloo`
Body:
`true`<br />
Response: 
```
{
    "statusCode": 200,
    "statusDescription": "Updated account violations",
    "recieved": null
}
```

### POST - `api/Account`
Body:
```
{
        "username": "test",
        "number_of_characters": 0,
        "violations": false
}
```
Response:
```
{
        "username": "test",
        "number_of_characters": 0,
        "violations": false
}
```
If account was created returns the account info

### DELETE - `api/Account/{username}`
#### Sucessful endpoint - `api/Account/test`
Response:
```
{
    "statusCode": 200,
    "statusDescription": "Deleted account",
    "recieved": null
}
```

## Player Table Samples

### GET - `api/Player`
Response:
``` 
[
    {
        "id": 1,
        "name": "Jack",
        "username": "jaaack5",
        "last_location": "base4",
        "player_level": 97
    },
    {
        "id": 2,
        "name": "Connor",
        "username": "c2004",
        "last_location": "base3",
        "player_level": 54
    },
]
```
I only took the first two entries to shorten the sample

### GET - `api/Player/{id}`
#### Sucessful endpoint - `api/Player/1`
Response:
```
{
    "id": 1,
    "name": "Jack",
    "username": "jaaack5",
    "last_location": "base4",
    "player_level": 97
}
```

### GET - `api/Player/name/{name}`
#### Sucessful endpoint - `api/Player/name/Midnight`
Response:
```
[
    {
        "id": 12,
        "name": "Midnight",
        "username": "giger5giger",
        "last_location": "base3",
        "player_level": 63
    },
    {
        "id": 21,
        "name": "Midnight",
        "username": "jaaack5",
        "last_location": "base5",
        "player_level": 110
    }
]
```

### PUT - `api/Player/{id}`
#### Sucessful endpoint - `api/Player/1`
Body:
```
{
        "id": 1,
        "name": "JackJack",
        "username": "jaaack5",
        "last_location": "base5",
        "player_level": 98
}
```
Response:
```
{
    "statusCode": 200,
    "statusDescription": "Updated player info",
    "recieved": null
}
```

### PATCH - `api/Player/name/{id}`
#### Sucessful endpoint - `api/Player/name/1`
Body:
`"JJ"`<br />
Response: 
```
{
    "statusCode": 200,
    "statusDescription": "Updated player name",
    "recieved": null
}
```

### POST - `api/Player`
Body:
```
{
    "id": 26,
    "name": "TestPlayer",
    "username": "jaaack5",
    "last_location": "base3",
    "player_level": 55
}
```
Response:
```
{
    "id": 26,
    "name": "TestPlayer",
    "username": "jaaack5",
    "last_location": "base3",
    "player_level": 55
}
```
If player was created returns the player info and increments the number of characters the account has

### DELETE - `api/Player/{id}`
#### Sucessful endpoint - `api/Player/26`
Response:
```
{
    "statusCode": 200,
    "statusDescription": "Deleted player",
    "recieved": null
}
```
If player was deleted, decrements the number of characters the account has
