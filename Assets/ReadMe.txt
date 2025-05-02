By Linxdarkness

Summary
This is a 3rd-Person Character Controller with all the movement functionality (e.g. Jump, Crouch, Sprint and walk) without animations for Unity. The purpose of this tool is to give developer a quick and easy 3rd-Person character controller, with basically all functionality built-in for them to use. This is a tool that fulfills the primary function of making a game playable when you need something to move around a space.

How To Use
Basic Setup
1. Bring in the two prefabs Player and 3rdPersonCam into you Unity scene and remove the main camera that is already in the scene.
2. On the Player Prefab ensure that the Controller, Cam, Camera Rig and Cam Rotation references are set.
	a. For the controller just drag and drop the Character Controller on the Player prefab here.
	b. Go to the 3rdPersonCam in the hierarchy open it's drop down where you will see a main camera drag this to the cam reference.
	c. Drag in the 3rdPersonCam here.
	d. Drag in the 3rdPersonCam here.
3. Go to the Ground Mask click the dropdown and set it to Ground. If you don't have a ground layer in the dropdown there is an add layer button click it and you will see a list of layers. In an empty space make write Ground and there you have it you have a Ground layer.
4. Set the layer of all the floors, platforms and other objects the player can walk on to Ground. This will allow the player to jump.

References
3rd person controller, movement
https://www.youtube.com/watch?v=4HpC--2iowE&t=1022s
jump
https://www.youtube.com/watch?v=_QajrabyTJc&t=711s
3rd person camera using Cinememachine
https://docs.unity3d.com/Packages/com.unity.cinemachine@3.1/manual/index.html