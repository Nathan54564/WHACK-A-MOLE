using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    // timer variables
    public TextMesh timerText; // Reference to our Unity Text
    public float gameTimer = 30f; //30 seconds for game timer
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;

        if (gameTimer>0f)
        {
            timerText.text = "WHACK A MOLE: " + Mathf.Floor(gameTimer);
        }
        else
        {
            timerText.text = "GAME OVER";
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space)){
                Time.timeScale = 1;
                Application.LoadLevel(0);
            }
        }

    }
}
