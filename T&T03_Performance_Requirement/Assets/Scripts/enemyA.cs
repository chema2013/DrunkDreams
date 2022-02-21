using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyA : MonoBehaviour
{
    //defines the speed of the enemy
    float enemySpeed = 2f;
    
    //define explosion prefab as a variable
    public GameObject explosionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //set position of the enemy, it constantly moves to the left
		Vector3 enemy = new Vector3(-1, 0f, 0f);
        transform.position += enemy * enemySpeed * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks if the enemy has collided with another pbject
    void OnCollisionEnter2D(Collision2D other)
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //if the enemy hits the "deathSpace" object then it gets destroyed
        if(other.gameObject.CompareTag("deathGround"))
        {
            Destroy(gameObject);
        }

        //if the player hits the enemy by jumping on top of it, the enemy gets destroyed
        if(other.gameObject.CompareTag("character"))
        {
            //it spawns the explosion animation on top of the enemy
            Vector3 position = gameObject.transform.position;
            Instantiate(explosionPrefab, position, Quaternion.identity);

            //then it destroys the enemy
            Destroy(gameObject);
        }
    }
}
