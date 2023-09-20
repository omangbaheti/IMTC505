# IMTC505 Lab 1


## Scripts

`GamePoint.cs`

Script location: Assets/Scripts/GamePoint.cs
Used in the `PointObject` prefab

##### _Default Behaviors_ :
Used in the PointObject prefab. Any GameObject with this script would be treated as a object the player character can interact with. When the player character runs through this object, it will increase the points as seen it's component view, then remove itself from the scene. The GameObject with this script should have a collider. When the game starts, this will also disable any colliders in any of it's child GameObjects.

##### _Added Behaviors_:
Added behaviors to animate the rotation of a Coin.


`MovingPlatform.cs`

Script location: Assets/Scripts/MovingPlatform.cs
Used in Different GameObjects

##### _Added Behaviors_ : This script takes two transform positions as its parameters and interpolates the position of the platform between the given transforms. It also makes the gameobject tagged as "Player" a child of it to sync tranforms in OnTriggerEnter() event and un-childs it in OnTriggerExit() event to unsync the tranform with the platform.

`Graph.cs`

Script location: Assets/Scripts/Graph.cs
Used in the `Graph` Prefab

##### _Added Behaviors_ :
This script can Instantiate a prefab multiple times and interpolate their positions to visualise a surface in 3D. Implemented functions that can be visualised are Sine Wave, Multiple Sine Waves, Ripple and a Rotating Twisted Sphere

`GameManager.cs`

Script location: Assets/Scripts/GameManager.cs
Used in the `GameManager` prefab

##### _Default Behaviours_:
This script contains the game logic. The tasks this script does are as follows:
* When the game starts it does the following:
    1. Find and keep track of all the GamePoint objects. This information is used to calculate the max score.
    2. Record the starting position of the player character.

* Updates the text objects which are referenced (linked by dragging and dropping in the component view).
* Start the clock when character moves beyond StartDistance units away from the starting position recorded.
* Keep track of the points scored and the time remaining
* End game (i.e. disable scoring and stop timer) when max score reached or the time limit is reached.

Options in component view:

* Start Distance: the distance the character has to move for the game to start, in unity units
* Time Limit: The time limit of the game in seconds
* Points Text: Reference to the text object (GameObject with TextMeshPro GUI component) on a Canvas. Points information will be printed out to the element referenced here.
* Time Text:  Reference to the text object (GameObject with TextMeshPro GUI component) on a Canvas. Time information will be printed out to the element referenced here.

##### _Added Behaviors_ : 
Play an audio clip every time a coin is collected. 



## Added Assets

1. Coin Asset : Assets\ThirdPartyAssets\DavePixel\PirateCoin
2. Tween Frameworks: Assets\ThirdPartyAssets\LeanTween
3. Custom Skybox : Assets\ThirdPartyAssets\Fantasy Skybox FREE
4. Coin SFX : Assets\SFX\mixkit-game-treasure-coin-2038.wav


## Notable Added/Modified Prefabs

1. PointObject.prefab : Changed the asset from a basic sphere to a coin. Added functionality to play an AudioClip everytime its called
2. Graph.prefab : Visualises 3D mathematical surfaces by instantiating the Point.prefab hundreds of times and interpolating each prefab's positions.
3. Point.prefab : A basic cube with a shader to change its color based on position in 3D space. Instantiated by Graph.prefab
