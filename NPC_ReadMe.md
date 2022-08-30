# NPC ReadMe: 
The NPC_dart_thrower object's controller script has several assignments that may need to be made to become properly functional. 

# NPCController.cs assignments:
"Dart": game object, to be thrown by the NPC; currently set to the "red_dart" prefab.

"Dart Spawn": the actual spot in the prefab that dictates the transform of the thrown object. should already be assigned to the dart_spawn object in the prefab.

"Random Range Value": the value that dictates how much of a random range the NPC "aims" the darts at. will likely need to be adjusted on an individual basis, depending on the map.

"Dartboard": Object that the NPC aims the darts at.

"Dart Table": This ties in to the original darts game code, where the spawned darts for the game are tied to the dart table object. Some actual editing of this code may be required.
