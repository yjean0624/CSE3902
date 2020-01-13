Xingyue Zhao
7/10/2019
Sprint5
CameraController, PlayerFollowingCamera
Derek Opdycke
10 mintues
He constructed a list of cameras in case of that in sprint6 we need to implement a multicamera racing feature. The method AddCameraFollwoingMario is undertstandable, the parameter it uses is just the index of mario, most likely either 0 or 1. Then in the Draw method, he draws each camera using PlayerFollowing Camera class. This class used to be named as Camera class but then we realize we need more than one camera in order to satisfy sprint6 feature. So he changed its name. In the GetTransformation method, he uses Matrix class by providing view width and certain game objects. These objects will all be called in Draw method to draw individually. The two variable zoom and downwardOffset are just the value most satisfiable for this viewport. I don't know why he include the third parameter viewHeight of GetTransformation method without even using it.