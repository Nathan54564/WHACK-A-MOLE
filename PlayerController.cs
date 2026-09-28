using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;
    public int leftRightStatus = 1;
    public int upDownStatus = 1;
    public float step;
    public float[] zzzAxisArray = { -0.31f, -3.83f, -7.66f };
    public float[] xxxAxisArray = { 3, 0, -3 };
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime; // calculate distance to move

        if (Input.GetKeyDown("right") && leftRightStatus < 2)
        {
            leftRightStatus += 1;

            //Debug.Log("The status is: " + leftRightStatus);
        }

        if (Input.GetKeyDown("left") && leftRightStatus > 0)
        {
            leftRightStatus -= 1;

            //Debug.Log("The status is: " + leftRightStatus);
        }

        if (Input.GetKeyDown("up") && upDownStatus < 2)
        {
            upDownStatus += 1;

            //Debug.Log("The status is: " + upDownStatus);
        }

        if (Input.GetKeyDown("down") && upDownStatus > 0)
        {
            upDownStatus -= 1;

            //Debug.Log("The status is: " + upDownStatus);
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xxxAxisArray[leftRightStatus], 3, zzzAxisArray[upDownStatus]), step);

    }
}
