# Health
## Health.cs
* Abstraction interface for HealthController.cs
    * Allows game object to heal/take damage
## HealthController.cs
* Interface to take damage.
  * This script forces the gameobject to have a collider.
    * The colliders are what allows gameobject to communicate through collisions.
## HealthDriver.cs
* Implementation of health.
  * Contains information about the player's health.
  * Handles how player will take damage.
## DamageOnTrigger.cs
* Assumes that the current game object is a trigger.
  * When the trigger event happen, then the "collided" object will take damage.