Xingyue Zhao
6/21/2019
Sprint4
GameObject.cs and Sprite.cs
Derek Opdycke
10 min
GameObject: This is an abstract class helps the project to eliminate redundant code overall. Because we used to have the exact same functions in every enemy/block/item class, so with the help of GamObject class, we could remove all repetitive code by inheriting from this one class. 
Sprite: This is almost the same from the last sprint, except adding a new function at the end which takes care of the animation frame rate. By doing this, it helps the movement of sprites to be "smoother". Before this, we have a if statement to take animation changes very 2 seconds as well as physics changes. But now, we could make the sprites keep on moving without waiting for the frame to get updated.