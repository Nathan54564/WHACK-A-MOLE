using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.IO.Ports;

public class Hammer : MonoBehaviour
{
    public SerialPort serial = new SerialPort("\\\\.\\COM4", 9600);
    private string vlxstring;
    public float vlxFloat, scaleDistance = 1000;
    private bool serialState;

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
    mole1Move mol1;
    mole2Move mol2;
    mole3Move mol3;
    mole4Move mol4;
    mole5Move mol5;
    mole6Move mol6;
    mole7Move mol7;
    mole8Move mol8;
    mole9Move mol9;

    void Start()
    {
        serial.Open();
        //Debug.Log("VLX Active");
        serialState = true;

        hammerDownRotation = Quaternion.Euler(hammerDownAngle, transform.rotation.y, transform.rotation.z);
        hammerUpRotation = Quaternion.Euler(hammerUpAngle, transform.rotation.y, transform.rotation.z);

        score = 0;
        scoreText.text = "score: " + score;
        mol1 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole1Move>();
        mol2 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole2Move>();
        mol3 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole3Move>();
        mol4 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole4Move>();
        mol5 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole5Move>();
        mol6 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole6Move>();
        mol7 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole7Move>();
        mol8 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole8Move>();
        mol9 = GameObject.FindGameObjectWithTag("Mole").GetComponent<mole9Move>();
    }

    void Update()
    {

        if (serialState == true)
        {
            vlxstring = serial.ReadLine();
            float.TryParse(vlxstring, out vlxFloat);
            //transform.position = new Vector3(transform.position.x, 0.255f + (vlxFloat) / scaleDistance, transform.position.z);
            Debug.Log(vlxFloat);
        }

        if (Input.GetKeyDown(KeyCode.Space) || vlxFloat>20)
        {
            if (hammerIsUp)
            {
                SwingHammer(false, hammerDownRotation);
                if (hammerOnMole)
                {
                    UpdateScore();
                    mol1.HideMole();
                    mol2.HideMole();
                    mol3.HideMole();
                    mol4.HideMole();
                    mol5.HideMole();
                    mol6.HideMole();
                    mol7.HideMole();
                    mol8.HideMole();
                    mol9.HideMole();
                   
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