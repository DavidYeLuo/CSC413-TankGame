# Movement

## Tank folder
* Contains tank movement driver.

## Movement.cs vs MovementDriver.cs
* Movement.cs is movement driver but without the knowledge of dependencies such as player asset.
  * Movement.cs is an abstract class while MovementDriver.cs isn't.
* MovementDriver has mechanism to get player asset through using a special interface.

## MovementController.cs
* Subscribes to user movement inputs and does the moving through the use of the driver implementation.