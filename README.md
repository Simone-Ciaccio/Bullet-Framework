# Description

This is a framework that can be used as a base to build a Bullet Hell type of game.

# How to use

After cloning the repository open Unity Hub and open the cloned unity project.\
\
If in Unity there is nothing in the scene, in Assets\Scenes there is a SampleScene file, open it to load the scene.\
\
The important objects in the scene are: Player, BulletSpawner, BulletManager and TimedLevel.\
\
TimedLevel is not active by default because if you activate it, it is supposed to execute the code necessary to create a timed level that spawn bullets in the pattern specified in the script TimedLevel1 found in Assets\Scripts\TimedLevels.\
\
On the Player you can set the starting HP, the cooldown to register the next damage (by default it is set to 0.2 so the Player can only take damage every 0.2 seconds) and with how much speed the player can move.\
\
The BulletSpawner is one of the most important parts of the framework because it lets you spawn bullets:
- The check box "Spawning Automatically" lets you keep shooting the bullets indefinitely looping through the Spawn Datas indexes constantly changing the attack type.
- If you want to make the attack type randon you just need to check the box "Is Attack Type Random".
- The list "Spawn Datas" is a list with "BulletSpwnData" scriptable objects, while the index indicates which scriptable object the script is using.
- The scriptable objects on the list can be found in Assets\Scripts\Data.
- To create one of these scriptable objects you can just right-click on the project tab -> Create -> ScriptableObjects -> BulletSpawnData.
In each of these scriptable objects you have different options:
- the Bullet Resource lets choose what GameObject or prefab you want to use as a bullet.
- with Min and Max rotation you can choose the angles between where the bullets can shoot.
- you can specify the number of bullets that are shot at the same time.
- if you tick the "Is Random" box the bullets will shoot at a random direction between the min and max angles, otherwise they will be distributed evenly between the directions.
- the "Is Not Parent" box lets you choose if you want the bullets to be created as a child of the bullet spawner or not.
- cooldown is the amount of time it takes for the next bullet to shoot.
- you can also specify the speed of the bullet and and the direction (keep in mind that the bullet direction is the point relative to the spawner where the bullet will shoot torwards if the angles are set to 0).

\
If you add this new scriptable object to the "Spawn Datas" list in the BulletSpawner you will have a new attack type for the bullet spawner.  
