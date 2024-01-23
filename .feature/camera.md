# Camera2D for 2D Platformer

We can use various approach to place camera in game.

But what we want to achieve?
- Camera attached to player
- When player died, camera still on last position
- Set camera boundries dynamically
- In future, we want add complex scene like story scene that play automatically (it will need more than one camera in scene tree)

So, here the approach based what we know

### 1. Internal camera with search
    This approach we place camera in player scene and link the camera with external GetChildByType() method or simple explanation is search player node and get the camera

    This approach is known hardcoded because we only get single instance from search method also if player is not available

### 2. Level Camera with RemoteTransform2D
    This approach is mostly used because based on tutorial. We used RemoteTransform to link the camera in child level scene or parent of player by mean it is outside the player scene.

    This approach is known good to use but hard to handle dynamic story scene

### 3. Static Level Design
    This approach use static level. Static level is level that independent defined by classes. So, each level is unique and entirely handled by code. 
    
    With this approach it will be superior to handle complex story scene but will cost at nightmare on procedural level and dynamic level

### 4. Dynamic Level Design
    This approach use dynamic level where each scene identified as unique or instance so dynamically handled by code.

    For instance like the level has story scene, then we using the code to handle that, and if the level is standard we using default template for the level