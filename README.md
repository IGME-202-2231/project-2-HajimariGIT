# Project _Up The Stakes_

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

_REPLACE OR REMOVE EVERYTING BETWEEN "\_"_

### Student Info

-   Name: Jonathan Ciottone
-   Section: _#5_

## Simulation Design 

Oh No! vampires have invded a local neighborhood. Watch as the people will try to run into their houses and the vampires roam to collect their dinner. But they need to be careful, the hunters are out....


1. Vampires will wander and chase humans in their vicinity. They will avoid unoccupied houses. They will also try to stay in bounds of the camera and seperate.
2. Humans will flee vampires but also seek shelter. If a vampire spots a human in a house they may chase them out. Humans will have to decide wether to run or go to their house. Some houses are locked and not able to get into...
leaving some humans out for good. they also try to stay in bounds of the camera.
3. Hunters will seek the closest vampire to themself.

### Controls

Right click to place sunspots that the vampires will avoid. 


## _Agent 1 Name_

The Hunter (seeker)

### _State 1 Name_

defaultSeeker

#### Steering Behaviors

SeekNear - seeks nearest vampire
Seek - used in seek near
Stay in bounds- stay in camera 

   
#### State Transistions

no transition
   
### _State 2 Name_

N/A professor said 3 agents with one having a state change was okay. 

#### Steering Behaviors

N/A professor said 3 agents with one having a state change was okay. 

#### State Transistions

N/A professor said 3 agents with one having a state change was okay. 






## _Agent 2 Name_

Vampire (wanderer)

### _State 1 Name_

wander

#### Steering Behaviors

Wander - wander around the map
Stay In Bounds - stays in bounds of camera
Avoid Obstacles - avoid obstacles
Seperate - seperate from other vampires


#### State Transistions

When a human is not close 


### _State 2 Name_

hunt 

#### Steering Behaviors
Avoid Obstacles - avoid obstacles
SeekNear - seek near humans 


#### State Transistions

When a human is close 







## _Agent 1 Name_

Human (fleer)

### _State 1 Name_

defaultFlee

#### Steering Behaviors

FleeAllStart/Flee all - flees all vampires that are close
Flee- used in flee all
StayInBoundsV2 - stays in bounds but seeks house

   
#### State Transistions

no transition
   
### _State 2 Name_

N/A professor said 3 agents with one having a state change was okay. 

#### Steering Behaviors

N/A professor said 3 agents with one having a state change was okay. 

#### State Transistions

N/A professor said 3 agents with one having a state change was okay. 














## Sources

-   _List all project sources here –models, textures, sound clips, assets, etc._
-   _If an asset is from the Unity store, include a link to the page and the author’s name_
https://dronnie.itch.io/cute-vampire-character vampire placeholder sprite

## Make it Your Own

I will be doing my own art and will have multiple weapons for hunters. 
Each with their on functionallity and art.
Art will be exaggerated and cartoony.

## Known Issues

_List any errors, lack of error checking, or specific information that I need to know to run your program_

### Requirements not completed

_If you did not complete a project requirement, notate that here_

