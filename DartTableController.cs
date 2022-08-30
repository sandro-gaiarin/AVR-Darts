using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I should have called this a dart spawn controller.
/// </summary>
public class DartTableController : MonoBehaviour
{
    [Tooltip("List of dart objects that should be spawned on the table")]
    public List<GameObject> Darts = new List<GameObject>();
    [Tooltip("List of darts' spawn positions, populated at Runtime")]
    public List<Vector3> dartSpawnPositions = new List<Vector3>();
    [Tooltip("List of darts' spawn rotations, populated at Runtime")]
    public List<Quaternion> dartSpawnRotations = new List<Quaternion>(); //list of the darts' spawn rotations

    // Start is called before the first frame update
    /// <summary>
    /// Initalize darts at Start().
    /// See InitalizeDarts().
    /// </summary>
    void Start() {InitializeDarts();}

    // Update is called once per frame
    void Update() {}

    /// <summary>
    /// Initializes darts at startup. Freezes the spawned darts in place,
    /// adds their positions and rotations to the respective lists.
    /// </summary>
    void InitializeDarts()
    {
        for (int i = 0; i < Darts.Capacity; ++i)
        {
            Darts[i].GetComponent<Rigidbody>().Sleep(); //freeze spawned darts in place
            dartSpawnPositions.Add(Darts[i].GetComponent<Rigidbody>().position); //store each dart's vector3 pos
            dartSpawnRotations.Add(Darts[i].GetComponent<Rigidbody>().rotation); //store each dart's vector3 rotation
        }
    }

    /// <summary>
    /// ResetDarts() is called by a button object that's a child of the dart table prefab.
    /// Respawns the darts to their initial start positions.
    /// </summary>
    public void ResetDarts()
    {
        for (int i = 0; i < Darts.Capacity; ++i)
        {
            Darts[i].GetComponent<Transform>().position = dartSpawnPositions[i];
            Darts[i].GetComponent<Transform>().rotation = dartSpawnRotations[i];
            Darts[i].GetComponent<Rigidbody>().Sleep();
            Darts[i].GetComponent<DartController>().thrown = false;
        }
    }
}
