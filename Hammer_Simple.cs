using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hammer_Simple : MonoBehaviour
{
    private bool hammerIsUp = true;
    private float hammerDownAngle = 0;
    private float hammerUpAngle = 90;
    private Quaternion hammerDownRotation;
    private Quaternion hammerUpRotation;
    private float hammerDownMaxTime = 0.25f;

    public AudioSource MoleGetsHit;

    private int score = 0;
    [SerializeField]
    private TextMesh scoreText;

    private bool hammerOnMole = false;
    private Mole moleScript;

    void Start()
    {
        hammerDownRotation = Quaternion.Euler(hammerDownAngle, transform.rotation.y, transform.rotation.z);
        hammerUpRotation = Quaternion.Euler(hammerUpAngle, transform.rotation.y, transform.rotation.z);

        score = 0;
        scoreText.text = "score: " + score;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hammerIsUp)
            {
                SwingHammer(false, hammerDownRotation);
                if (hammerOnMole)
                {
                    UpdateScore();
                    //moleScript.MoveDown(); // Move mole down when hit
                }
            }
            else
            {
                SwingHammer(true, hammerUpRotation);
                if (hammerOnMole)
                {
                    //moleScript.MoveUp(); // Move mole up when the hammer goes up
                }
            }
        }

        if (!hammerIsUp)
        {
            hammerDownMaxTime -= Time.deltaTime;
            if (hammerDownMaxTime <= 0f)
                SwingHammer(true, hammerUpRotation);
        }
    }

    void SwingHammer(bool hammerUp, Quaternion hammerRotation)
    {
        hammerIsUp = hammerUp;
        transform.rotation = hammerRotation;

        if (hammerIsUp)
            hammerDownMaxTime = 0.25f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Mole")
        {
            hammerOnMole = true;
            moleScript = collision.gameObject.GetComponent<Mole>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Mole")
        {
            hammerOnMole = false;
            moleScript = null;
        }
    }

    void UpdateScore()
    {
        score++;
        MoleGetsHit.Play();
        scoreText.text = "score: " + score;
    }
}

