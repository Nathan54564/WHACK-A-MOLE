using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mole5Move : MonoBehaviour
{
    public float visibleYHeight = 2.0f;
    public float hiddenYHeight = -1.6f;
    private Vector3 myNewXYZPosition;
    public float speed = 4f;
    public float hideMoleTimer = 1.5f;
    public statusSaver script;
    //public int status;
    // Start is called before the first frame update
    void Start()
    {
        HideMole();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, myNewXYZPosition, Time.deltaTime * speed);
        if (script.status == 5)
        {
            ShowMole();
        }
        else
        {
            HideMole();
        }

    }

    public void HideMole()
    {
        myNewXYZPosition = new Vector3(transform.localPosition.x, hiddenYHeight, transform.localPosition.z);
    }

    public void ShowMole()
    {
        myNewXYZPosition = new Vector3(transform.localPosition.x, visibleYHeight, transform.localPosition.z);

        hideMoleTimer = 1.5f;
    }
}
