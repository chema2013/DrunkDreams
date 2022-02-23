using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBall : MonoBehaviour
{

    //speed of the fireball
    float fireSpeed = 4f;


    void OnEnable()
    {
        //makes the script a coroutine
        StartCoroutine(waiter());
    }

    void FixedUpdate()
    {

        // defines the variables needed for the sine movement
		float frequency = 10f; // velocity of the movement
		float amplitude = 4.5f; // the amplitude for the curves
		int maximum = 65; // maximun value the sine can reach
		int minimum = -65; // minimum value the sine can reach
		
		//defines the  sine
		float sineBehaviour;
		sineBehaviour = Mathf.Sin(frequency * Time.time);
		sineBehaviour *= amplitude;
		sineBehaviour = Mathf.Clamp(sineBehaviour, minimum, maximum);
    
		// set the position of the gameobject using the sine result
        Vector3 ball = new Vector3(0f, sineBehaviour, 0f);
        transform.position += ball * Time.fixedDeltaTime;


        //set position of the fireball, it constantly moves to the right
		Vector3 fireBall = new Vector3(1, 0f, 0f);
        transform.position += fireBall * fireSpeed * Time.fixedDeltaTime;
    }



    // Update is called once per frame
    void Update()
    {

    }

    //countdown to destroy the spinballs
        IEnumerator waiter()
{

    //waits 3 second before making another action
    yield return new WaitForSeconds(3);

    //once the time is completed it destroys the object
    Destroy(gameObject);
}
}
