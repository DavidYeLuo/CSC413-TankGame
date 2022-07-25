# Player Creation

## PlayerCreator
This class serves as an interface from the system(Game manager) to the player creator. 
**GameManager is the class responsible for the actual creation.**

## Note
**This class uses the player data(Data folder) to create a player.**

## Customizing Player
I've decided that the game manager class will be responsible to create a customized player.
Meaning that the PlayerCreator isn't responsible for what data it gets. Other than the copies of the player data.

### How to Customize Player Data?
The GameManager should change the values in the Data folders to do that before creating the player.
**Note: Might want to change the values back after creating the player.**