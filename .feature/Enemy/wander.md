# Wander/Patrol Mechanics

### 1. Fixed Path Patrol

 Enemies follow a predetermined path, moving back and forth or in a loop. This is commonly seen in platformer games where enemies need to cover specific ground.

- __Example Games:__ Classic platformers like Super Mario Bros., where enemies like Goombas and Koopa Troopas have set patterns.


### 2. Random Patrol with Constraints
 Enemies move randomly but within defined constraints, such as a specific area. This approach can make the enemy movement seem less predictable and more dynamic.

- __Example Games:__ Games like Terraria or Minecraft, where certain enemies roam within specific biome boundaries with semi-random patterns.


### 3. AI State Machine
 Enemies have a set of states (e.g., idle, wander, chase, attack) and transition between these states based on AI rules. This method allows for complex behaviors based on the player's actions or environmental factors.

- __Example Games:__ Hollow Knight uses AI states for its enemies, making them switch between patrolling, chasing the player, and attacking based on the player's proximity and actions.


### 4. Navigation and Pathfinding
 Enemies use the game's navigation system to move towards a target or wander within an area. Pathfinding algorithms (like A* or Dijkstra's) help enemies navigate around obstacles.

- __Example Games:__ In Astral Ascent and similar games, enemies might use pathfinding to chase the player or return to their patrol route after losing sight of the player.


### 5. Utility-Based AI
 Decisions are made based on scoring various actions (like patrolling, chasing, fleeing) based on the current situation. The highest-scoring action is chosen. This approach allows for nuanced decision-making.

- __Example Games:__ More complex AI systems, such as those in some RPGs and strategy games, might use this for enemy behavior, though it's less common in straightforward platformers.


### 6. Scripted Behavior with Variability
 Specific behaviors are scripted for certain game events or triggers, but with elements of randomness or variability to keep the gameplay fresh.

- __Example Games:__ Games with heavy narrative elements or specific level design considerations, where enemy behaviors need to fit the story or challenge design, such as Celeste or the Ori series.


### 7. Behavior Trees
 Enemies use behavior trees, which provide a structured way to select and execute actions based on a hierarchical set of conditions. This is more flexible and easier to manage than a simple state machine for complex AI.

- __Example Games:__ Complex games with varied enemy AI might employ this method for nuanced behaviors, allowing for both predictable patterns and dynamic responses to player actions.
Each of these approaches has its pros and cons and can be chosen based on the specific needs of the game, such as the desired complexity of enemy behavior, the level of interactivity with the environment, and the overall feel the developers wish to achieve. Often, a combination of these methods is used to create a more engaging and varied AI system for enemies in a game