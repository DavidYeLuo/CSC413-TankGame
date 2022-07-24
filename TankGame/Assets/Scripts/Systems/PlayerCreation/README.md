# Player Creation
## Overview
Handles with creating and linking up dependencies such as player data, player inputs, and camera.
## Creation driver
Have all the implementations for creation such as CameraCreation, InputCreation, and PlayerCreation.

## CameraCreation
Can create a camera but it is mainly used for linking the camera to the player game object.

## InputCreation
Traverse Unity's InputSystem to get the necessary inputs and pass it to the created player.

## PlayerCreator
This class serves as an interface from the system(Game manager) to the player creator. 