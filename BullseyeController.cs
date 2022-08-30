using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>BullseyeController</c> registers a hit to the bullseye within the target.
/// </summary>
public class BullseyeController : MonoBehaviour
{
    bool hit = false; //hit status

    /// <summary>
    /// Getter, hit status
    /// </summary>
    /// <returns>Bool, true if hit</returns>
    public bool GetHit()
    {
        return hit;
    }

    /// <summary>
    /// Setter of hit status. Meant to change hit to "false" after a registered hit.
    /// </summary>
    /// <param name="b">bool, updated hit status.</param>
    public void SetHit(bool b)
    {
        hit = b;
    }

    /// <summary>
    /// Registers a hit if the trigger collider has the "Dart" tag, and that
    /// dart has thrown == true.
    /// </summary>
    /// <param name="other">Trigger collider</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart") && other.GetComponent<DartController>().thrown)
        {
            hit = true;
        }
    }
}
