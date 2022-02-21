using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodenPlatform : MonoBehaviour
{
    //an array with the collision which is going to keep the character from falling
    public GameObject[] platform = new GameObject[1];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is pressing the key "s" so the character could go throught the platform
        if(Input.GetKeyDown("s"))
        {
            platform[0].SetActive(false);
        }
    }

    //checks if the platform has collided with something
    void OnTriggerEnter2D(Collider2D other)
    {
        //checks if the platform has collided with the character and disables the collision gameobject that is on top of the platform
        if(other.gameObject.CompareTag("character"))
        {
            platform[0].SetActive(false);

        }
    }

    //performs an action once an object leaves the trigger area
    void OnTriggerExit2D(Collider2D other)
    {
        //checks if the player has already left the trigger area and enables the collision gameobject that is on top of the platform
        if(other.gameObject.CompareTag("character"))
        {
            platform[0].SetActive(true);

        }
    }
}
