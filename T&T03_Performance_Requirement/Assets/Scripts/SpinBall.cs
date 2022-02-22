using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBall : MonoBehaviour
{

    //variable that makes reference to the gameobject that is going to be the parent of this gameObject
    public GameObject spinObject;

    //speed of the fireball
    float fireSpeed = 4f;

    //reference to the player's gameobject
    public GameObject player;

    void Awake()
    {
        //changed the parent of every heart that will be spawned
        gameObject.transform.parent = spinObject.transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        
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
        float positionCharacter = player.transform.position.x;

        float positionFire = transform.position.x;

        if(positionFire - positionCharacter >= 25)
        {
            Destroy(gameObject);
        }

    }
}
