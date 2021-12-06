controllers/DefaultController - main controller, has one method "GetTop10"

Objects
	Player - contains the player details 
	Team - contains the Team details
	Season - contains the stastics of the season
	PlayerYear- combine the player object and the season
	PlayerYearList - singleton - list of PlayerYear
	JsonPlayer - inner object to deserialize json
	JsonTeams - inner object to deserialize json


JsonUtils - has utils function to download data and deserialize them
PlayerUtils - has the logical methods to get the top 10 players
