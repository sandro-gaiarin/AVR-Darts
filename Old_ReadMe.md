/// Dartboard ReadMe:
/// 
/// @author 
/// This program was created in Unity by Alessandro Gaiarin,
/// with the help and brainstorming of Nathan, AJ, John, Chris, and Caius.
/// 
/// @about
/// In order to make the game work, you should only need to drag the dart_table
/// and dartboard prefabs into your scene. The VR framework is the BNG Framework,
/// and that is required as the darts use the grabbable script.
/// 
/// @see dartboard (prefab)
/// the dartboard prefab uses a model from Synty's clubs/bars pack. The controller
/// script (DartboardController.cs) is attached to one of its colliders,
/// "Whole Board Collider". The script needs the score text, hover text, and bullseye
/// colliders assigned; all of those objects are included in the prefab.
/// 
/// @see dart_table (prefab)
/// the dart_table prefab uses models from Synty. The DartTableController.cs script is attached
/// to the prefab. It does require a list of the darts that spawn in on the table; six are
/// provided. The Button grandchild "InnerButton" calls the ResetDarts() function that
/// can be found in DartTableController.cs; this is required for the reset button to work.
/// 
/// @see dart (prefab) and red_dart (prefab)
/// the red_dart prefab is a variant of dart. For multiplayer functionality, make sure 
/// red_dart has the "Player Two" boolean checked. The "Thrown" boolean should not be
/// used on either dart variant.

