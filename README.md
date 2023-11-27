# Online hackathon 2023 - ShootScares API

## The ShootScares API is a web service designed to help manage player information for an exciting browser-based game. It provides a set of CRUD actions for players, necessary actions to record game results, and an endpoint to retrieve the leaderboard.

### Set up Project <br>

#### Prerequisites : <br>
.NET SDK, SQL Server
#### Clone repository : <br>
`git clone https://github.com/KristinaKhozina/hackathon_2023.git`
<br>
#### Navigate to the project directory : <br>
`cd hackathon_2023/ShootScares.API`
<br>
#### Install Dependencies : <br>
`dotnet restore`
<br>
#### Run Entity Framework Core migrations to create the necessary database schema : <br>
`dotnet ef database update`
<br>
#### Run API using CLI: <br>
`dotnet run`
<br>
#### Access the Swagger UI at https://localhost:7101/swagger or http://localhost:5205/swagger in your browser.
### Overview
Endpoint |  Description |  Response body
 --- | --- | ---
GET /api/players | Get all players and their game results | Array of player models with associated game results
GET /api/players/{id} | Get a specific player and their game results | Player model with associated game results
POST /api/players | Create a new player | Newly created player model with associated game result
PUT /api/players/{id}	| Update an existing player | Updated player model
DELETE /api/players/{id} | Delete a player | No content 
GET /api/results | Get all players' results | Array of game result models
GET /api/results/{id} | Get a specific game result | Game result model
POST /api/results | Create a new game result | Newly created game result model
DELETE /api/results/{id} | Delete a specific game result | No content 
GET /api/leaderboard | Get top 5 scores and usernames for the leaderboard | Array of leaderboard items


