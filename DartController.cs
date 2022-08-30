using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG; //VR framework import

/// <summary>
/// Class <c>DartController</c> controls the basic throwing physics of the darts.
/// </summary>
public class DartController : MonoBehaviour
{
    private GameManager gameManager;
    Rigidbody rb; //dart rigidbody
    Grabbable grabScript; //dart's Grabbable script
    bool isGrabbed = false; //is the dart currently being grabbed?
    bool wasGrabbed = false; //was the dart being grabbed before?
    [Tooltip("Check this box if this dart is meant for player 2/NPC points tracking")]
    public bool playerTwo; //true if this is a player 2 dart
    [Tooltip("True if the dart has been recently thrown (do not edit)")]
    public bool thrown; //true if the dart has been recently thrown

    // Start is called before the first frame update
    /// <summary>
    /// Initialize dart rigidbody and the Grabbable script on Start().
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabScript = GetComponent<Grabbable>();
        gameManager = GameObject.Find("Darts Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    /// <summary>
    /// The script checks if the dart was previously grabbed.
    /// If the dart is no longer being grabbed, but previously was, then
    /// it is assumed the dart has been thrown. The X and Y rotations
    /// on the rigidbody are locked so the dart flies true, assisting the player.
    /// </summary>
    void FixedUpdate()
    {
        if (grabScript.BeingHeld)
        {
            isGrabbed = true;
        }
        else if (isGrabbed && !grabScript.BeingHeld)
        {
            isGrabbed = false;
            wasGrabbed = true;
            thrown = true;

            if (gameManager.GetNonPlayerCharActive())
            {
                gameManager.throwAllowedNPC = true;
            }
        
        }
        else
        {
            isGrabbed = false;
        }

        if (wasGrabbed) //changing this to thrown instead of wasGrabbed causes issues
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    /// <summary>
    /// Upon collision, the X and Y rotation values will be unlocked, assuming the dart
    /// has been thrown in the first place.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (wasGrabbed)
        {
            wasGrabbed = false;
        }
    }
}
