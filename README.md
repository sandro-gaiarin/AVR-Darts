# AVR-Darts
Scripts for a virtual reality darts experience, made in Unity. The content of these scripts was produced under the employ of AccessVR, LLC.

# About
In order to make the game work, you should only need to drag the dart_table and dartboard prefabs into your scene. The VR framework is the BNG Framework, and that is required as the darts use the grabbable script.

The dartboard prefab uses a model from Synty's clubs/bars pack. The controller script (DartboardController.cs) is attached to one of its colliders, "Whole Board Collider". The script needs the score text, hover text, and bullseye colliders assigned; all of those objects are included in the prefab.  

The dart_table prefab uses models from Synty. The DartTableController.cs script is attached to the prefab. It does require a list of the darts that spawn in on the table; six areprovided. The Button grandchild "InnerButton" calls the ResetDarts() function thatcan be found in DartTableController.cs; this is required for the reset button to work.

The red_dart prefab is a variant of dart. For multiplayer functionality, make sure  red_dart has the "Player Two" boolean checked. The "Thrown" boolean should not be used on either dart variant.
