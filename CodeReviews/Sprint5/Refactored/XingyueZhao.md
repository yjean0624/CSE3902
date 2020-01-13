Xingyue Zhao
7/12/2019
Sprint5
CameraController, ICamera, PlayerFollowingCamera
Derek Opdycke
Code smells:
Large class: all classes are not very large.
Cyclomatic complexity: the only two loops he uses are to draw each objects in the level and each camera views
Orphan variable or constant classes: he put all the magic numbers in Config classes
Excessively long line of code: each line of codes are not too long
Inappropriate intimacy: The playerFollowingCamera class has dependency on GameManager class, but nothing to do with details of that class.
Right now, I think the camera class has ability to hold more than one player views. The current code of PlayerFollowingCamera class should be able to print multi-headsUpDisplay, but need to remove instance.
