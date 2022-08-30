using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>DartboardController</c> controls most of the dartboard game.
/// The script must have the text objects and bullseye collider attached to it to function properly.
/// </summary>
public class DartboardController : MonoBehaviour
{
    Rigidbody dartRB; //representation of a dart hitting the target
    [Tooltip("Score tracking text")]
    public TextMeshPro scoreText;
    [Tooltip("Popup text, used for \"Bullseye!\"")]
    public TextMeshPro hoverText;
    int score; //player 1 score
    int p2Score = 0; //player 2 score
    [Tooltip("Collider of the bullseye")]
    public Collider bullseyeCollider;
    BullseyeController beController; //BullseyeController; see associated script
    float bullseyeCountdown = 0;

    // Start is called before the first frame update
    /// <summary>
    /// Initalizes score, both text objects, and the bullseye controller.
    /// </summary>
    void Start() 
    {
        score = 0;
        scoreText.text = "BLUE:\n" + score + "\n\nRED:\n" + p2Score;
        hoverText.text = "";
        beController = bullseyeCollider.GetComponent<BullseyeController>();
    }

    // Update is called once per frame
    /// <summary>
    /// Updates the score, as well as the Bullseye hover text.
    /// </summary>
    void Update()
    {
        scoreText.text = "BLUE:\n" + score + "\n\nRED:\n" + p2Score;
        if (bullseyeCountdown > 0)
        {
            Debug.Log(bullseyeCountdown);
            bullseyeCountdown -= Time.deltaTime;
            hoverText.text = "Bullseye!";
        }
        else
        {
            hoverText.text = "";
        }
    }

    /// <summary>
    /// Checks if a dart collides with the target.
    /// Also calls beController for possible bullseye hit.
    /// </summary>
    /// <param name="other">collider of object, possible dart</param>
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Dart") && other.GetComponent<DartController>().thrown) //check if other is a dart, and the dart has been thrown
        {
            dartRB = other.GetComponent<Rigidbody>(); //get the dart's rigidbody
            dartRB.velocity = new Vector3(0, 0, 0);
            dartRB.Sleep(); //put dart rigidbody to sleep, keeping the dart in place on target hit
            if (!other.GetComponent<DartController>().playerTwo)
            {
                score++;
                if (beController.GetHit())
                {
                    bullseyeCountdown = 3;
                    beController.SetHit(false);
                    score += 4;
                }
            }
            else
            {
                p2Score++;
                if (beController.GetHit())
                {
                    bullseyeCountdown = 3;
                    beController.SetHit(false);
                    p2Score += 4;
                }
            }
            other.GetComponent<DartController>().thrown = false;
        }
    }
    
    /// <summary>
    /// Resets scores to 0.
    /// </summary>
    public void ResetScores()
    {
        score = 0;
        p2Score = 0;
    }
}

