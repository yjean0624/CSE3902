# Author : Levi Zhou

Date: 7/12/2019
Sprint: 5
File: HeadsUpDisplay.cs
Author: Xingyue Zhao
Time: 2 mins

Cohesion: high
Cohesion is pretty high, everything needs displaying on the HUD is included in this file.

Coupling: decent
Coupling is relatively low, reference of this class is pretty low. But the ConvertToString method could be private, it is only called by the Draw method. And it should not be called by outside classed.

Additional notes:

Potential Change:
Methods: LoadAllFonts and ConvertToString could be changed to private.
