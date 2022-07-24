# AttachToPlayer

## Overview
Handles with creating and linking up dependencies such as player data, player inputs, and camera.
This class serves as a guiding tool for the PlayerCreator.cs on how components should initialize.
**The scripts in this folder don't handle creation**

## Creation driver
Have all the implementations for creation such as CameraCreation, InputCreation, and PlayerCreation.

## CameraCreation
Can create a camera but it is mainly used for linking the camera to the player game object.

## InputCreation
Traverse Unity's InputSystem to get the necessary inputs and pass it to the created player.
These classes doesn't create the player prefab.
