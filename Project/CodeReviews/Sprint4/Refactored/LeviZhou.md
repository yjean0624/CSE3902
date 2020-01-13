# Sprint 4 Refactored Code Review

Author: Levi ZHou
Date: 6/28/2019
Sprint: 4
File: Camera.cs
Name: Derek Opdycke
Minutes: 10

Cohesion: Pretty Good
Camera.cs does exactly what it's supposed to. It takes spriteBatch, gameTime, and window Size to make a window for all sprites that need drawing.

Coupling: Decent
Camera.cs doesn't need too many arguements except a list of all objects that need to be drawn and the size of the centered player.

Hypothetical change:
The window may not need center the player exactly, just make the left upper corner of player be the center of the window should be good. GameObjects these are not in the camera may not need drawing, and this could potentially get better performance.
