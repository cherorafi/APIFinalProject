# APIFinalProject
This is an API that can do CRUD operations on a database consisting of 2 tables Accounts and Players.

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
