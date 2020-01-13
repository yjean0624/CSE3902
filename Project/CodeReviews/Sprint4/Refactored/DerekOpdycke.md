Code Quality

Class does too much or too little?
Only one public method (DetectCollision) but it does exactly what the class is for and nothing else.

Methods do too much?
Methods do only what they are suppose to.

Shotgun surgery?
I can't see any changes that would require changes to other classes.

Duplicated Code?
The intersection of the hitboxes happens twice. 
CheckCollision might just return the intersection rectangle 
and use that to determine direction rather than find it again.

Inappropriate Intimacy?
CollisionDetector knows nothing about anything else except some 
information about how the collidable lists are ordered which is 
an unseen, but purposeful, rule put in to make the the dictionaries
shorter.

Data Clump?
There are not any groups of data being unnecessarily being passed around.

Cyclomatic Complexity?
DetectCollision has 2 loops nested in another loop. (N=4) This isn't excessive. 
CollisionDirection has if-else statements inside if-else statements. (M=4)
This is also not excessive.

Too Many Parameters?
Methods and Constructors only take what they need.
