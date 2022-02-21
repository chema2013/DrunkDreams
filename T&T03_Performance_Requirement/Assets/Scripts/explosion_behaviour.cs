using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //makes the script a coroutine
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator waiter()
{

    //waits 1 second before making another action
    yield return new WaitForSeconds(1);

    //once the time is completed it destroys the object
    Destroy(gameObject);
}
}
