using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterBehaviour : MonoBehaviour
{
    //normal speed while moving
    float characterSpeed = 5f;

    //speed when the character is running
    float characterRun = 13f;

    //jump force applied to character when pressing space
    float jump = 31f;

    //is true if the character is jumping
    bool isJumping;

    //makes an arrays with the animations needed for the character movement
    public GameObject[] animations = new GameObject[4];

    //an int that defines the amount of hearts the character currently has
    public int health = 0;

    //public variable where the score will be store
    public static int points;


    //using the event Awake to define  the elements once the object is enable, at the start of the level
    void Awake()
    {
        //spawns a heart sprite on top of the screen, showing the character's health
        GameObject heart = GameObject.FindWithTag("heart");

        Vector3 position = new Vector3(27, 15, 0);
		Instantiate(heart, position, Quaternion.identity);

        //set the amount of hearts the character has, adds one because one heart has been added to his health
        health += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Using FixedUpdate to move the player before anything else happens in the game e.g. camera movement    
    void FixedUpdate()
    {
        /*gets the key being pressed by the player and makes the character move to the right or left, if the leftshift key is being pressed then the character runs
        (used GetKey and not GetKeyDown since the movement should happen while the key is being pressed)*/
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a")) || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d")))
        {
            //Vector3 is define before adding it to the position of the player and adds the fastes value for the character "characterRun"
            Vector3 character = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += character * characterRun * Time.fixedDeltaTime;

            //making sure the correct animation is being played, by changing from the standing character to the runing animation
            animations[1].SetActive(true);
            animations[0].SetActive(false);

        }
        else if  (Input.GetKey("a") || Input.GetKey("d"))
        {
            //Vector3 is define before adding it to the position of the player
            Vector3 character = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += character * characterSpeed * Time.fixedDeltaTime;

            //making sure the correct animation is being played, by changing from the standing character to the runing animation
            animations[1].SetActive(true);
            animations[0].SetActive(false);
        }
        else
        {
            //making sure that when the player isn't pressing any movement key the animation that is shown is the player standing still
            animations[1].SetActive(false);
            animations[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
         /*Putting the jump in another if statement since the character should be able to move mid air while jumping 
        (it is in the update event since it has a quicker reaction, tried putting it in the fixedupdate but it has a delay when pressing the space bar)*/
        if(Input.GetKeyDown("space") && isJumping == false)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            //checks if the player is currently jumping
            isJumping = true;
        }

        //if the death animation is being played after losing every heart then the level is reloaded and print the text "dead"
        if(animations[3].activeSelf == true)
                {
                    Debug.Log("dead");
                    SceneManager.LoadScene(0);
                }
    }

    //checks if the player has collided with another object
    void OnCollisionEnter2D(Collision2D other)
    {
        //turns the jumping bool to false when the character has landed
        if(other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("woodenPlatform"))
        {
            isJumping = false;
        }

        //checks if the player hits an enemy
        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("enemyB"))
        {
            //if the player only has one heart then the character dies and plays the death animation
            if(health == 1)
            {
                Destroy(animations[1]);
                Destroy(animations[0]);
                animations[2].SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //checks if the player has reached the end, the safebar
        if(other.gameObject.CompareTag("end"))
        {
            Debug.Log("you reached the end!");
        }

        //if the player collides with the deathGround object the level restarts
        if(other.gameObject.CompareTag("deathGround"))
        {
            SceneManager.LoadScene(0);

            //prints the phrase you died once the character died and the scene is reloaded
            Debug.Log("You died");
        }


        //three situations (the player collects three different types of srews)

        //checks if the player has collected the first srew type (small one)
        if(other.gameObject.CompareTag("screw1"))
        {
            //destoys the screw item so it can't be collected anymore
            Destroy(other.gameObject);

            //since is the first screw it gives one point to the player
            points ++;
            Debug.Log("1 point");
        }

        //checks if the player has collected the second srew type (medium one)
        if(other.gameObject.CompareTag("screw2"))
        {
            //destoys the screw item so it can't be collected anymore
            Destroy(other.gameObject);

            //since is the first screw it gives five points to the player
            points += 5;
            Debug.Log("5 point");
        }

        //checks if the player has collected the second srew type (medium one)
        if(other.gameObject.CompareTag("screw3"))
        {
            //destoys the screw item so it can't be collected anymore
            Destroy(other.gameObject);

            //since is the first screw it gives ten points to the player
            points += 10;
            Debug.Log("10 point");
        }
    }


    void LateUpdate()
    {
    }
}
