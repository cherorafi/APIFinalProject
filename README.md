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
    

