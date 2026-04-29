
# GDIM33 Vertical Slice
## Milestone 1 Devlog
My UI Visual Scripting graph is used to update the ammo and health displays on the UI. It uses custom events that are called in the Player and EnemyStates graphs start the sequences. The sequence that updates the current ammo display starts with the updateAmmo custom event being triggered, then gets the relevant TextMeshPro object via ammoText Scene variable. This text is set to a concatenation of the string "Ammo: " and the Player object's ammo variable. Nearly identical sequences are done for the ammo reserves and health displays as well, albeit with different variables and no concatenation when setting the reserves text. The updateAmmo and updateReserves events are triggered on start as well to ensure that the player's ammo can be changed in the inspector and update properly immediately. 

In my breakdown, I added a separate section for the state machine system, as it is a large part of the game but primarily affects the monster. Four bubbles represent the states, with arrows between them representing the transitions. The main interactions from outside the state machine itself are the player and Navmesh system (via the terrain), which are represented with arrows or labels for these connections. The state machine is attached to the monster and controls its behavior, including movement, attacks, and animations. The monster starts in the wandering state, where it randomly set a new destination every few seconds using the Navmesh system. It also plays the walking animation. If a raycast simulating vision hits the player, or if they get too close, the monster enters the chasing state. In this state, the destination is instead set to the player and the NavMeshAgent's speed and angular speed properties are increased. The running animation is also played instead of the walking animation. If the monster loses line of sight or gets too far for a few seconds, it returns to the wandering state. If the monster gets close enough to the player, however, it enters the attacking state. In this state, the speed is reduced and the monster deals damage roughly every second, coinciding with the attack animation. If the player gets too far away, the monster enters the chasing state. At any point, if the monster is shot, it enters the stunned state. In this state, it resets the Navmesh path and so stops moving, playing the hit animation then the stunned animation. Once the stunned animation is over after a few seconds, the monster switches to the chasing state. Most of the states have an if statement to prevent the monster from seeing or attacking the player when they are hiding in a locker. This state machine gives the monster a somewhat realistic AI system that can maneuver the environment and affect and be affected by the player. 

Breakdown:
<img width="2168" height="1224" alt="33 Breakdown (4)" src="https://github.com/user-attachments/assets/eb33e70c-d9fb-410b-a9fd-c872668968a2" />

## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
