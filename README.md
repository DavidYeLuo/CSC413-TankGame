# csc413-tankgame

# Project Structure Layout

## Builds

Contains builds to run and play. Supported platforms: Windows, Linux, and Mac.

## TankGame/Assets

Contains assets for the game. All of the sounds and models are imported from outside source. I wrote almost all the scripts(Except PlayerControls.cs).

## TankGame/Assets/Scripts.

Contains runnable code. For more information about the scripts see the readme file inside the project.

# Required Information when Submitting Tank Game

## Version of Unity Used: 2021.3.3f1 LTS

## IDE used: JetBrains Rider 2022.2
For educational use only.
Runtime version: 17.0.3+7-b469.32 amd64
VM: OpenJDK 64-Bit Server VM by JetBrains s.r.o.
Linux 5.15.0-41-generic
.NET 6.0.6
GC: G1 Young Generation, G1 Old Generation
Memory: 1500M
Cores: 4
Registry:
    ide.new.project.model.index.case.sensitivity=true
    rdclient.asyncActions=false
    indexing.enable.entity.provider.based.indexing=false

Non-Bundled Plugins:
    IdeaVIM (1.10.3)

Current Desktop: Unity

## Steps to Import project into IDE: 
Since I'm using Unity the game is run in the Unity application. Meaning this step shouldn't matter. All the code are located in TankGame/Assets/Scripts

## Steps to import project into Unity: 
Open the project in the TankGame folder.(**Not** in the root folder)

## Steps to run your Project: 
* Options to run
    * Run from Builds (Simplest)
    * Check before running
        * In the top left visit File>BuildSettings...
            * Build the project
                * Make sure that there are 2 scenes inside the Scenes in Build box.
                    * Those are Scenes/MainMenu and Scenes/Gameplay
                    * If they are not there then add it manually
                        1. Open the scene (Not sure if order matters but I would open MainMenu first)
                        2. Visit File>BuildSettings again
                        3. Click on AddOpenScenes
                        4. Repeat this step for the other scene.
            * Run the game in the Unity Window.
                1. Visit the directory Assets/Scenes
                2. Open the MainMenu Scene.
                3. In the top middle of the window there are three small icon, click the left one to run the game.

## Steps to Build your Application:
* Visit the File>BuildSettings 
* Make sure that the scenes are in the build settings. (Read Steps to run your Project on how to do that)
* Choose the target platform you want and build it.

## Controls to play your Game:

|              |  Keyboard  |
| ------------ | :--------: |
| Forward      |     W      |
| Steer Left   |     A      |
| Backward     |     S      |
| Steer Right  |     D      |
| Shoot        | Left Click |
| Look         |   Mouse    |
| Start(Pause) |    Esc     |

Note: This has local split screen game which supports with game controllers(Inputs might differ). However, it doesn't support split keyboard.
