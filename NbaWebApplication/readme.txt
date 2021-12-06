controllers/DefaultController - main controller, have one method "GetTop10"

Objects
	Player - contains the player details 
	Team - contains the Team details
	Season - contains the stastics of the season
	PlayerYear- combine the player object and the season
	PlayerYearList - singleton - list of PlayerYear
	JsonPlayer - inner object to deserialize json
	JsonTeams - inner object to deserialize json


JsonUtils - have utils function to download data and deserialize them
PlayerUtils - have the logical methods to get the top 10 players
