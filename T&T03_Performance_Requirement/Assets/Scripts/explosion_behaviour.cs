using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_behaviour : MonoBehaviour
{
    //variable for the sound that is going to play
    public AudioSource explosion;

    // Start is called before the first frame update
    void Start()
    {
        //makes the script a coroutine
        StartCoroutine(waiter());
    }

    void OnEnable()
    {
        explosion.Play(0);
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
