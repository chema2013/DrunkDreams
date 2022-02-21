using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyB : MonoBehaviour
{
    //awake event searching the x value at the start of the game
    void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
		// defines the variables needed for the sine movement
		float frequency = 1.0f; // velocity of the movement
		float amplitude = 4.4f; // the amplitude for the curves
		int maximum = 65; // maximun value the sine can reach
		int minimum = -65; // minimum value the sine can reach
		
		//defines the  sine
		float sineBehaviour;
		sineBehaviour = Mathf.Sin(frequency * Time.time);
		sineBehaviour *= amplitude;
		sineBehaviour = Mathf.Clamp(sineBehaviour, minimum, maximum);
    
		// set the position of the gameobject using the sine result
        Vector3 enemy = new Vector3(sineBehaviour, 0f, 0f);
        transform.position += enemy * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
