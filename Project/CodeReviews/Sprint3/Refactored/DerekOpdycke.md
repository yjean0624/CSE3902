Code Quality

Class does too much or too little?
Everything in this class seems like it needs to be there.

Methods do too much?
Most methods are only 1 line of code and the Update method does an appropriate amount of stuff.

Shotgun surgery?
I can't see any changes to this class that would require other classes to need to change.

Duplicated Code?
There is no duplicated code within the class however there are many methods which share the
exact same code with the same methods in other classes so an abstract class should be created.

Inappropriate Intimacy?
There does not seem to be any inappropriate intimacy.

Data Clump?
There are no constants but there is a magic number with millisecondsPerFrame. This should
probably become part of the sprite class and be read in from the xml file.

Cyclomatic Complexity?
All but one method only has a single line of code and the only one that doesn't 
just has an if statement.

Too Many Parameters?
Only 2 methods have parameters and they are both used correctly.
