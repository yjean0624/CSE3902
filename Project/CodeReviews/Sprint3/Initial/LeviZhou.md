# Author: Levi Zhou

Date: 6/13/2019
Sprint: 3
Creator of File Reviewed: Oliver Ding
File: PlayerWithCoin.cs
Minutes: 25

Coupling: high
The Class PlayerWithCoin is coding to Player and Coin. In the switch cases, this class will call the 
methods of player and coin. Therefore coupling in this file is relatively high, but I think it's 
necessary. If there is any way to lower down the coupling of this method, please let me know.

Cohesion: medium
The switch cases includes 4 different situations of collision. In each case, methods of players and 
coins will be called respectively. So I don't think cohesion here is high.

Additional Notes:
As TA discussed in Sprint 2 feedback, we could use using Project.GameObjects instead of using
GameObjects.IGameObject Player. And same thing could be done in PlayerWithBrownMushroom.cs. Besides
TA also suggested not using "this.myPlayer" when unnecessary.

Potential Change:
All the ICollisionResponses were implemented similarly, it should be my fault since I started it
that way. But to lower down the coupling here, we may add a method called collision response for ICollidable
and all the ICollisionResponses should just invoke the method for appropriate ICollidable.