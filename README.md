
# GDIM33 Vertical Slice
## Milestone 1 Devlog
My UI Visual Scripting graph is used to update the ammo and health displays on the UI. It uses custom events that are called in the Player and EnemyStates graphs start the sequences. The sequence that updates the current ammo display starts with the updateAmmo custom event being triggered, then gets the relevant TextMeshPro object via ammoText Scene variable. This text is set to a concatenation of the string "Ammo: " and the Player object's ammo variable. Nearly identical sequences are done for the ammo reserves and health displays as well, albeit with different variables and no concatenation when setting the reserves text. The updateAmmo and updateReserves events are triggered on start as well to ensure that the player's ammo can be changed in the inspector and update properly immediately. 

In my breakdown, I added a separate section for the state machine system, as it is a large part of the game but primarily affects the monster. Four bubbles represent the states, with arrows between them representing the transitions. The main interactions from outside the state machine itself are the player and Navmesh system (via the terrain), which are represented with arrows or labels for these connections. The state machine is attached to the monster and controls its behavior, including movement, attacks, and animations. The monster starts in the wandering state, where it randomly set a new destination every few seconds using the Navmesh system. It also plays the walking animation. If a raycast simulating vision hits the player, or if they get too close, the monster enters the chasing state. In this state, the destination is instead set to the player and the NavMeshAgent's speed and angular speed properties are increased. The running animation is also played instead of the walking animation. If the monster loses line of sight or gets too far for a few seconds, it returns to the wandering state. If the monster gets close enough to the player, however, it enters the attacking state. In this state, the speed is reduced and the monster deals damage roughly every second, coinciding with the attack animation. If the player gets too far away, the monster enters the chasing state. At any point, if the monster is shot, it enters the stunned state. In this state, it resets the Navmesh path and so stops moving, playing the hit animation then the stunned animation. Once the stunned animation is over after a few seconds, the monster switches to the chasing state. Most of the states have an if statement to prevent the monster from seeing or attacking the player when they are hiding in a locker. This state machine gives the monster a somewhat realistic AI system that can maneuver the environment and affect and be affected by the player. 

Breakdown:
<img width="2168" height="1224" alt="33 Breakdown (5)" src="https://github.com/user-attachments/assets/6b5f803f-ec30-476d-b8fc-e5b541788490" />


## Milestone 2 Devlog
1. As I have already implemented the sanity system, I have chosen to break down the implementation of the player's weapon animations.
   1. Set up the animator controller 
      - Create an animator controller and add the relevant clips
      - Edit the clips to have loop time enabled
      - Create booleans and triggers for different transition actions
      - Create transitions between the clips using the booleans and triggers
      - Ensure the idle animation plays correctly

   2. Set up the transition functionality in script
      - Make a variable to reference the new animator controller
      - Set the moving boolean to true in the moving sequence if the inputs are zero, then test if it plays and stops correctly
      - Set the firing trigger to true in the firing sequence and sync the firing cooldown to the animation length
      - Set the reloading trigger to true in the separate reloading script and make it only play if the player actually reloaded ammo
      - Prevent the player from reloading again and have the UI text update only once the animation is completed 
      - Tweak transition settings as needed to blend animations properly, testing after each change

2. The steps break-down was moderately useful, as it helped me think through the process I would take. However, there were some steps that ended up being more complicated than the steps covered, such as needing to significantly restructure the reloading node sequence and the transitions requiring the use of exit time. It helped me with the basics, but was not very helpful for the advanced implementation. The week 5 quiz was not useful because by that time I had already full implemented the Unity system. If I were to do them again, I would try to be a bit more specific and detail the complex parts if I can anticipate them.

3. I bridged visual scripting and code with the Player script, which has methods that are called via nodes in various sequences in the Player graph. I used it to do the math for reloading with the Reload method, which was much simpler to think about and program in script compared to using nodes. I also used the LockCamera and UnLockCamera methods for hiding, especially because the UnLockCamera method required a complicated if statement that would be annoying with nodes.

Reload usage sequence in graph:
<img width="2428" height="571" alt="Screenshot 2026-05-14 222207" src="https://github.com/user-attachments/assets/6d3745ec-6c7b-47b6-8cb6-adbfaf80f397" />

Lock and Unlock usage sequence in graph:
<img width="2493" height="589" alt="image" src="https://github.com/user-attachments/assets/305b3f1d-3471-4742-8273-cd7974a5ec2a" />

4. The Unity system I would like graded is the navmesh system, which is used to control the monster's movement.
## Milestone 3 Devlog


- Improved outer boundaries to make it so players can't escape
- Made the goal clear by having the world and ___ guide players ___
- Improved the movement, fixing collisions between the player and colliders
- Made it so the player can no longer jump, fixing various movement issues while not detracting from gameplay
- More consumables and lockers exist so that players ____
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- [Survivalist Character](https://assetstore.unity.com/packages/3d/characters/survivalist-character-181470) - Player model
- [RPG Animations](https://assetstore.unity.com/packages/3d/animations/free-32-rpg-animations-215058) - Player animations
- [Monster: Wolf Boss](https://assetstore.unity.com/packages/3d/characters/creatures/01-monster-wolf-boss-189463) - Monster model and animations
- [Low-Poly 3D Lockers](https://assetstore.unity.com/packages/3d/props/interior/low-poly-3d-lockers-239681) - Locker model
- [Ammo](https://assetstore.unity.com/packages/3d/props/ammo-157327) - Ammo box model
- [First Aid Set](https://assetstore.unity.com/packages/3d/props/first-aid-set-160073) - First aid kit model
- [Flashlight](https://assetstore.unity.com/packages/3d/props/electronics/flashlight-18972) - Flashlight model
- [AllSky Free](https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014) - Skybox
- [Street Lamps](https://assetstore.unity.com/packages/3d/props/exterior/street-lamps-165658) - Street lamp model
- [Strange Whispers](https://pixabay.com/sound-effects/horror-strange-whispers-415245/) - Low sanity whisper sounds
- [Footsteps - Essentials](https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879) - Footstep sounds
- [FPS Pistol Animations](https://sketchfab.com/3d-models/fps-pistol-animations-0d7a343dcb6f401197a73c91aee93f6d) - Gun/arms models and animations
- [Weapons of Choice - FREE](https://assetstore.unity.com/packages/audio/sound-fx/weapons/weapons-of-choice-free-101807) - Gunshot sound
- [Monster Bite](https://pixabay.com/sound-effects/horror-monster-bite-44538/) - Monster attack sound
- [Monster Growl](https://pixabay.com/sound-effects/horror-monster-growl-390285/) - Monster growl sound
- [Item Pickup](https://pixabay.com/sound-effects/film-special-effects-item-pickup-37089/) - Item pickup sound
