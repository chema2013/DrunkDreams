using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockWave : MonoBehaviour
{
    public screenShake shaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //this event starts the coroutine every time the gameobject is enable
    void OnEnable()
    {
        //makes the script a coroutine
        StartCoroutine(waiter());

        //starts coroutine (screenshake)
        StartCoroutine(shaker.Shake(.20f, .6f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     IEnumerator waiter()
{

    //waits 1 second before making another action
    yield return new WaitForSeconds(1);

    //once the time is completed it disables the sphere
    gameObject.SetActive(false);
}
}
