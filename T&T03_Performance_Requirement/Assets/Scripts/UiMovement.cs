using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMovement : MonoBehaviour
{

    //normal speed while moving
    float characterSpeed = 5f;

    //speed when the character is running
    float characterRun = 13f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        /*when the players moves this gameobject will follow it, changing it's direction depending on the key pressed by the player
        tthis moves with the same speed the character does*/
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a")) || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d")))
        {
            //Vector3 is define before adding it to the position of the player and adds the fastes value for the character "characterRun"
            Vector3 ui = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += ui * characterRun * Time.fixedDeltaTime;
        }
        else if  (Input.GetKey("a") || Input.GetKey("d"))
        {
            //Vector3 is define before adding it to the position of the player
            Vector3 ui = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += ui * characterSpeed * Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
