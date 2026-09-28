using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusSaver : MonoBehaviour
{
    public int status;
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            status = UnityEngine.Random.Range(1, 10);
            yield return new WaitForSeconds(2);
            Debug.Log("Started Coroutine at timestamp : " + status);
        }
        
    }
}