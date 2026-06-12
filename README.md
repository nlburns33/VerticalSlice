
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
1. The Shader Graph I made is used to display the bloody vignette effect on the screen when the player is hurt. The SampleTexture2D node gets the bloody vignette texture, the outputs of which are put into two other nodes. 
The alpha channel of the texture is multiplied by a sequence of nodes that makes the image fade in and out using a sine time node that is modified to be more consistent through adding and dividing. The result is then multiplied again, this time by a float that is controlled in the Player Script Graph. As the player's health decreases, this float gets higher and higher, increasing the resulting alpha and making the image more opaque. The final number is input into the alpha of the fragment shader.
The red, green, and blue channels of the texture are input into a combine node, gathering the channels into one output, which is then input into the base color of the fragment shader. This simply sets the effect's color, which doesn't change.
<img width="1940" height="1131" alt="Screenshot 2026-05-28 221416" src="https://github.com/user-attachments/assets/6d0a8871-a558-46d4-b1d4-839f56fc6354" />

3. I have made a fair few changes based on playtesting feedback, especially around movement. I significantly improved the movement system, fixing the player being able to move into and through colliders in unintended ways that playtesters noticed. 
With the new system, I removed the player's ability to jump, which added nothing to gameplay but was a source of various other collision issues. I changed the map's barriers, which when combined with the other changes stops players from being able to get over them and out of bounds. 
I made the monster easier to spot with a more significant light, as some players noted that it was difficult to see with the fog and darkness. I also made the monster more aggressive so that there a greater challenge. 
I added additional lockers and consumables, as players said there were too few which meant the player couldn't interact as much.
I made the map layout subtly guide the player towards the goal (the truck) while still having offshoots, as some players were unsure of where to go.

4. The majority of the content I added since the last milestone has been based around completely redoing the environment so the gameplay loop can be repeatedly experienced in more than just a testing space. 
I expanded the map alongside adding many new props and environmental assets to allow for more interesting opportunities for chases and hiding encounters. 
I also implemented a win condition, having the player escape the area by fleeing in a truck they interact with. This caps off the gameplay loop.
The premise of my game is meant to have only a single enemy that the player has to hide and run from but who can only be stunned and not killed, so it didn't make sense to add more enemies for feature 3. 
The features I have added are most of what remained to be completed from my pitch, and there aren't many things I could add to gameplay without requiring new systems. 
Thus, it made the most sense to add this kind of content as it lets the player experience the entirety of the gameplay while making it more interesting. 

## Final Devlog
1. The player tries to escape the maze-like environment while avoiding the monster using lockers and their pistol, staying alive by collecting health and ammo and maintaining their sanity. There is a monster that wanders, chases, and attacks the player, a weapon that can be used to stun the monster, 
and a complete environment with scattered lockers to hide in, lights to regain sanity, and health and ammo packs. There is also a win and loss condition, various visual effects, and sounds.
This vertical slice level contains the primary gameplay mechanics that would be present across the full game, so a player only needs to experience this short vertical slice in order to get a feel for how the rest of the game would play out. 
There would likely be additional weapons, monsters, maps, and smaller mechanics, but they would be similar enough that the full game could be extrapolated from what currently exists. Many new elements would be based on the existing elements and have a similar core feeling to the player. 

2. The bloody vignette rendering effect is activated through the Player Script Graph. In the Shader Graph, there is a float property and node that gets multiplied by the alpha channel. 
On update, the Player Script Graph gets the player's health, then divides this value by 100 and subtracts the result from 1 to create a higher float as the player's health decreases. The effect's material is then referenced to access the float property from the Shader Graph, and the float is set to the result of previous math. 
This makes the effect invisible when the player is at full health and slowly increases in opacity as the player's health decreases, creating a seamless transition.

3. While my current plan worked alright, I think that I could form a better plan. 
The first primary step would be to identify a core game mechanic or loop and focus on that, slowly adding more mechanics as needed to make it work. Then, I would identify the different primary systems that could be used to utilize the mechanics and create the overall gameplay experience. 
Next, I would identify variables and components to support the function of the mechanics. These could all be simply noted down and organized in a document. 
Once the primary parts of the game are envisioned, I could visualize them with a diagram of all the parts and their relationships or a systems diagram with the game loops. 
Bubble diagrams would work well to reveal many of the connections necessary to integrate the various systems and parts together. Having them contain the rough scripting functions of each part would help when implementing them later on.
Task step break-downs could help later on when preparing to implement a feature, but seem less useful early on in planning. 
This plan is, in a way, more detailed in terms of specifics than what I followed for my vertical slice project, but not that far off. I ended up having to change a few aspects from the original plan for the vertical slice, but I think this is a universal problem that can't be fully solved with a different plan.
It was difficult to figure out where all the scripting functionality would go, so I likely could have benefited from the more in-depth bubble diagrams with scripting details in my new plan.
Having an outline of individual features, in the pitch and in a Trello board, was useful as a way to keep track of progress and get a rough idea of what order to tackle systems in. 
Planning a big project in small steps like this allows you to better visualize the scope of a project, making it easier to see if it is too large to be tackled realistically.
However, if planned poorly (if the plan is too simple), it could also make the project seem easier than it actually is. If you have a good plan, then more can be added later on if needed, more easily than otherwise.

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
- [Yughues Free Ground Materials](https://assetstore.unity.com/packages/2d/textures-materials/nature/yughues-free-ground-materials-13001) - Ground textures
- [Old sheds](https://assetstore.unity.com/packages/3d/props/exterior/old-sheds-304824) - Metal shed model
- [URP Tree Models](https://assetstore.unity.com/packages/3d/vegetation/trees/urp-tree-models-253340) - Tree models
- [Wood Box Pack](https://assetstore.unity.com/packages/3d/props/industrial/wood-box-pack-15-objects-105811) - Wooden props
- [Industrial Models](https://assetstore.unity.com/packages/3d/props/industrial/industrial-models-171071) - Pipes, fuel tank, and pallet models
- [Urban Building](https://assetstore.unity.com/packages/3d/props/exterior/urban-building-130318) - Central building model
- [Industrial Buildings & Props](https://assetstore.unity.com/packages/3d/environments/industrial/industrial-buildings-props-13173) - Large building, small stone building, and garage models
- [PBR Dirt Dumpster](https://assetstore.unity.com/packages/3d/props/exterior/pbr-dirty-dumpster-59840) - Dumpster model
- [PBR RPG/FPS Game Assets](https://assetstore.unity.com/packages/3d/environments/industrial/pbr-rpg-fps-game-assets-industrial-set-v1-0-146519) - Shipping containers and fuel tank models
- [Yughues Free Bushes](https://assetstore.unity.com/packages/3d/vegetation/plants/yughues-free-bushes-13168) - Bush models
- [Pickup Truck](https://sketchfab.com/3d-models/pickup-truck-047615f53e2d45b9a1a2a4dd203d459c) - Pickup truck model
- [Blood Vignette](https://www.deviantart.com/7he1ndigo/art/Blood-Vignette-704205045) - Bloody effect texture
- [Free Quick Effects](https://assetstore.unity.com/packages/vfx/particles/free-quick-effects-vol-1-304424) - Muzzle flash effect
- [Horror Background Atmosphere 025](https://pixabay.com/sound-effects/musical-horror-background-atmosphere-025-499631/) - Background ambience
