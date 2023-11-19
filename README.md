# Project _Up The Stakes_

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

_REPLACE OR REMOVE EVERYTING BETWEEN "\_"_

### Student Info

-   Name: Jonathan Ciottone
-   Section: _#5_

## Simulation Design 

Oh no! a team of vampire hunters have been amushed by vampires!  Play as air support and drop important supplies to help them survive. Watch as the vampire hunters struggle to gain materials to stop them! 

### Controls

Press right click to give the hunters wood blocks to craft weapons. Be careful with your placement as you only have so many.



## _Agent 1 Name_

The hunter will avoid the vampires and try to group up when needed with other agents. If the hunter has enough resources for a weapon then it will chase and kill vampires.

### _State 1 Name_

Survive 
Run away and group up with other hunters

#### Steering Behaviors

Flee - from vampires 
Group - toward other hunters
Pull - take one hunter out of the group to get a weapon. If not in a group that one goes

   
#### State Transistions

When ones resource is good enough for a weapon
When one is picked to get wood from the group
When a group is found 
   
### _State 2 Name_

Kill

#### Steering Behaviors

Kill- will prioritize seeking lower level vampires first and vampires that have killed before 

#### State Transistions

When enough wood is gathered

## _Agent 2 Name_

The vampire wil separate from the flock if there is enough vampires and hunt the hunters

### _State 1 Name_

Feed
Chase hunters seperate from the group (if there are non try to get one in the group).
#### Steering Behaviors

Take - Seeks and pulls a hunter away from the pack quickly (can be done once.
Suck - find hunters with no group
#### State Transistions

Default state if vampires are doing well.
   
### _State 2 Name_

Survive 
#### Steering Behaviors

Hide - Group up with other vmpires 
Avoid - avoid the hunter
   
#### State Transistions

if vampires population is less than half.

## Sources

-   _List all project sources here –models, textures, sound clips, assets, etc._
-   _If an asset is from the Unity store, include a link to the page and the author’s name_
https://dronnie.itch.io/cute-vampire-character vampire placeholder sprite

## Make it Your Own

- _List out what you added to your game to make it different for you_
- _If you will add more agents or states make sure to list here and add it to the documention above_
- _If you will add your own assets make sure to list it here and add it to the Sources section

## Known Issues

_List any errors, lack of error checking, or specific information that I need to know to run your program_

### Requirements not completed

_If you did not complete a project requirement, notate that here_

