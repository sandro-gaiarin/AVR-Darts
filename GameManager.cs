using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DARTS MANAGER
public class GameManager : MonoBehaviour
{
    //Game Objects:
    [Tooltip("dart_table prefab")]
    public GameObject dartTable;
    [Tooltip("dartboard prefab")]
    public GameObject dartBoard;
    [Tooltip("NPC_dart_thrower prefab")]
    public GameObject dartNPC;

    public bool throwAllowedNPC = false;
    Animator npcAnimator;


    /// <summary>
    /// NPC is not active on game start.
    /// </summary>
    // Start is called before the first frame update
    void Start() 
    { 
        dartNPC.SetActive(false);
        npcAnimator = dartNPC.GetComponent<Animator>();
    }

    // Update is called once per frame
    /// <summary>
    /// If NPC is active and allowed to make a throw, the ThrowDartNPC()
    /// coroutine is called.
    /// </summary>
    void Update()
    {
         /* //IGNORE, TEST For testing coroutine:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ThrowDartNPC());
        } */

        if (throwAllowedNPC && GetNonPlayerCharActive()) //a thrown dart from a player will set this to true
        {
            StartCoroutine(ThrowDartNPC()); // makes the NPC throw a dart after a 2 second wait
            throwAllowedNPC = false;
        }
    }

    /// <summary>
    /// Coroutine; the NPC waits for two seconds after the player has thrown,
    /// then throws their own dart.
    /// </summary>
    /// <returns></returns>
    IEnumerator ThrowDartNPC()
    {
        npcAnimator.SetTrigger("Throw Dart");
        //npcAnimator.SetBool("Is Idle", false);
        yield return new WaitForSeconds(2);
        dartNPC.GetComponent<NPCController>().ThrowDart();
        //npcAnimator.ResetTrigger("Throw Dart");
        //npcAnimator.SetBool("Is Idle", true);
    }

    /// <summary>
    /// Sets the NPC's active state (awake/asleep).
    /// </summary>
    public void SetNonPlayerCharActive()
    {
        dartNPC.SetActive(!GetNonPlayerCharActive());
    }

    /// <summary>
    /// Gets the NPC's active state.
    /// </summary>
    /// <returns>bool, true if the NPC is awake, false if the NPC sleeps.</returns>
    public bool GetNonPlayerCharActive()
    {
        return dartNPC.activeSelf;
    }

    /// <summary>
    /// Resets game scores. I don't think this works.
    /// </summary>
    public void ResetScores() //TODO test this, might no longer need
    {
        dartBoard.GetComponent<DartboardController>().ResetScores();
    }

    /// <summary>
    /// Resets the NPC's thrown darts. This is likely no longer needed.
    /// </summary>
    public void ResetNPCDarts() //TODO test this, might no longer need
    {
        dartNPC.GetComponent<NPCController>().DeleteThrownDarts();
    }
}
