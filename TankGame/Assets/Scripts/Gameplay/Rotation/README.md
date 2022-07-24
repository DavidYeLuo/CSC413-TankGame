# Rotation

## Tank folder
* Contains tank look driver.

## Rotator.cs vs LookDriver.cs
* Rotator is the abstract class. It contains the interface to use rotation.
* LookDriver implements Rotator class and also loads player assets to use.
  * NOTE: Currently there isn't an implementation for the default look driver for general purpose but there is an implementation for the tank.

## LookController.cs
* Subscribes to user look inputs and rotates based on the inputs.