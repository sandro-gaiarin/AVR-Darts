using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    //TODO:
    // **DONE dartSpawn angle (rotation transform) needs to slightly adjust between every throw.
    // amount of angle change maybe could be affected by difficulty settings
    //
    // **DONE NPC throw needs to change the "throw" bool in DartController for the darts to count as points
    //
    // **DONE darts need a despawn functionality added
    //
    // DeleteThrownDarts algo currently has some unintended behavior, see below in Update()
    //
    // Clean up code!

    [Tooltip("Game Object to be thrown")]
    public GameObject dart;
    [Tooltip("Object in the prefab that dictates the initial transform of the thrown object")]
    public GameObject dartSpawn;
    [Tooltip("Value that dictates how much of a random range the NPC \"aims\" the darts at")]
    public float randomRangeValue = 6; //value that dictates how much of a random range the NPC "aims" the darts at.
    [Tooltip("AI throwing force")]
    public float throwForce = 500f;
    Vector3 initialDartSpawnRotation;
    List<GameObject> dartsThrown = new List<GameObject>();
    [Tooltip("Dartboard Object, needed for aiming the Dart Spawn angle")]
    public GameObject dartboard; //dartboard object, needed for aiming the dartSpawn
    [Tooltip("The table the darts spawn on (should be dart_table prefab)")]
    public GameObject dartTable;
    public List<GameObject> dartList;

    Animator npcAnimator;

    // Start is called before the first frame update
    /// <summary>
    /// On game start, the darts with Player 2 tags are identified,
    /// and the dart spawn object is aimed towards the dartboard.
    /// </summary>
    void Start()
    {
        PopulateDartList();
        dartSpawn.transform.LookAt(dartboard.transform); //aims the dartSpawn towards the dartboard
        initialDartSpawnRotation = dartSpawn.transform.eulerAngles;

        npcAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {}

    /// <summary>
    /// Throws a dart with a slightly randomized angle.
    /// </summary>
    public void ThrowDart()
    {
        if (dartList.Count > 0)
        {
            // set random ranges for the throw angle
            float randX = Random.Range(-randomRangeValue, randomRangeValue);
            float randY = Random.Range(-randomRangeValue, randomRangeValue);
            // reset dartSpawn back to original angle so it doesn't get out of wack
            dartSpawn.transform.eulerAngles = initialDartSpawnRotation;
            // set the new throw angle using the random ranges
            dartSpawn.transform.eulerAngles += new Vector3(randX, randY, 0);

            GameObject newDart = dartList[0];
            newDart.GetComponent<Transform>().position = dartSpawn.GetComponent<Transform>().position;
            newDart.GetComponent<Transform>().rotation = dartSpawn.GetComponent<Transform>().rotation;

            newDart.GetComponent<DartController>().thrown = true;
            newDart.GetComponent<Rigidbody>().AddForce(dartSpawn.transform.forward * throwForce);
            dartList.RemoveAt(0);
        }
    }

    /// <summary>
    /// Deletes dart objects that have been thrown by the NPC.
    /// </summary>
    public void DeleteThrownDarts()
    {
        foreach (GameObject dart in dartsThrown)
        {
            Destroy(dart);
        }
        dartsThrown.Clear();
    }

    /// <summary>
    /// Adds red darts (player 2 darts) spawning on the table to local dartList,
    /// making them available for the NPC to throw.
    /// </summary>
    public void PopulateDartList()
    {
        List<GameObject> dartTableList = dartTable.GetComponent<DartTableController>().Darts;

        for (int i = 0; i < dartTableList.Count; ++i)
        {
            if (dartTableList[i].GetComponent<DartController>().playerTwo)
            {
                dartList.Add(dartTableList[i]);
            }
        }
    }
}
