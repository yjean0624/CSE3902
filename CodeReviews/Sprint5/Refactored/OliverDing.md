CodeQuaulity review Author of the code review : Oliver Ding

Date of the code review : 07/12/2019 

Sprint number : 5

Name of the .cs file being reviewed: SoundEffectManager.cs

Author of the .cs file being reviewed: Levi Zhou

Number of minutes taken to complete the review: 15 mins

Class itself does a fairly good job similar to levelManager.cs and spriteMachine.cs which focus on making list for all the potential sound tracks for Level1-1 and underground levels. It has some valid methods including PlaySoundEffect(BGM) and Stop SoundEffect(BGM). The class itself could be considered of low coupling and high cohension since the class does not inherit any furthur interfaces or classes. The class does a small variety of functions and is not related to or dependent on additional classes or interfaces.
Some code smell: Shotgun surgery, since the class does not use a xml file to hold all the wav(mp3) files. Instead, using a list to add all the sounds and determine which BGM or sound to play. This could also cause Data Clump that a mixture of BGM and sound are passed around together in various parts of the program, better solution will be using two lists to add and separate BGM and sounds like the ColliadableList and uncolliabaleList. 

