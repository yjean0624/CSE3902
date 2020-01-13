Author: Levi Zhou
Date: 6/13/2019
Sprint 3
Name: Derek Opdycke
File: SpriteMachine.cs
Minutes: 30

Coupling: low
SpriteMachine only refered to a few files, XMLData.Frame, Sprites.Frame. And only referred by MyGame.cs, so coupling of this class is pretty low.

Cohesion: high
SpriteMachine used many internal classes, and each of them only does a specific job such as spriteTag.

Additional Notes:
This is SpriteMachine is data driven as well. But there are XMLData.Frame and Sprites.Frame get used, and it may make more sence if they have different names.

Hypothetical Change:
SpriteMachine is pretty well-structured, and it has gone beyond my ability to improve it.
