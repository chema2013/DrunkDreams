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

    //variable to indicate if the player has the upgradeA
    bool hasUpgradeA;

    //variable to indicate if the player has the upgradeA
    bool hasUpgradeB;

    //variable for new scale when picking upgrades
    private Vector3 newScale;

    //array for hearts, show how many lives the player currently has
    public GameObject[] hearts = new GameObject[2];


    //using the event Awake to define  the elements once the object is enable, at the start of the level
    void Awake()
    {
        //enables the heart sprite in the ui, showing the character's health
        hearts[0].SetActive(true);

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


        //checks if the has collected the upgrade A
        if(hasUpgradeA == true)
        {
            //checks the health of the player and this happens if they didn't get another upgrade
            if(health == 1)
            {
            //spawns a heart sprite on top of the screen, showing the character's health, this only happens if the character doesn't have a second heart
            GameObject heart_ = GameObject.FindWithTag("heart");
            
            Vector3 position_ = new Vector3(20, 15, 0);
            Instantiate(heart_, position_, Quaternion.identity);
            }

            //if the player has the upgrade they can perform the special movement/ shoot fireballs
            if (Input.GetKeyDown("e"))
            {
                //everytime the player uses the upgrade, a firebal is sapwned
               GameObject ball = GameObject.FindWithTag("spinBall");

               float positionX = transform.position.x + 5f;

               float positionY = transform.position.y - 4f;

               //defined the vector3 position using the player's position as reference
               Vector3 position = new Vector3(positionX, positionY, 0f);

            Instantiate(ball, position, Quaternion.identity); 

            //print message
            Debug.Log("fire!");
            }

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

                //disables first heart in the ui, showing that the player has no health
                hearts[0].SetActive(false);
            }

            //if the player collected the upgrade
            if(health == 2)
            {
                //makes the player loose one heart
                health --;
                //disables the other upgrades
                hasUpgradeA = false;
                hasUpgradeB = false;

                //disables second heart in the ui, showing that the player has one lives
                hearts[1].SetActive(false);

                //disables the first upgrate sptite in the ui, showing that the player doesn't have that upgrade
                hearts[2].SetActive(false);

                //disables the second upgrate sptite in the ui, showing that the player doesn't have that upgrade
                hearts[3].SetActive(false);

                //prints a message saying that the player lost the upgrade
                Debug.Log("You lost the upgrade");

                 //define the values for the new scale
                newScale = new Vector3(-2f, -2f, -2f);

                //changes the scale of the player back to normal
                transform.localScale += newScale;
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



        //two situations for the upgrades pick ups

        //checks if the player collided with the upgradeA sprite
        if(other.gameObject.CompareTag("upgradeA"))
        {
            //destoys the upgrade item so it can't be collected anymore
            Destroy(other.gameObject);

            //changes the value of the upgrade bool to state that the player has the upgrade
            hasUpgradeA = true;

            //disables the  other upgrade, in case it was acquired
            hasUpgradeB = false;

            //enables second heart in the ui, showing that the player has two lives
            hearts[1].SetActive(true);

            //enables the first upgrate sptite in the ui, showing that the player has that upgrade
            hearts[2].SetActive(true);

            //disables the second upgrate sptite in the ui, showing that the player has replaced it
            hearts[3].SetActive(false);

            //prints message
            Debug.Log("picked up UpgradeA");
            
            //this happens if the player doesn't have another upgrade
            if(health == 1)
            {

                //define the values for the new scale
                newScale = new Vector3(2f, 2f, 2f);

                //changes the scale of the player
                transform.localScale += newScale;
                
                //set the amount of hearts the character has, adds one because one heart has been added to his health (the upgrade add one more heart)
                health += 1;
            }
        }

        //checks if the player collided with the upgradeB sprite
        if(other.gameObject.CompareTag("upgradeB"))
        {
            //destoys the upgrade item so it can't be collected anymore
            Destroy(other.gameObject);

            //changes the value of the upgrade bool to state that the player has the upgrade
            hasUpgradeB = true;

            //disables the  other upgrade, in case it was acquired
            hasUpgradeA = false;

            //enables second heart in the ui, showing that the player has two lives
            hearts[1].SetActive(true);

            //enables the second upgrate sptite in the ui, showing that the player has that upgrade
            hearts[3].SetActive(true);

            //disables the first upgrate sptite in the ui, showing that the player has replaced it
            hearts[2].SetActive(false);

            //prints message
            Debug.Log("picked up UpgradeB");
            
            //this happens if the player doesn't have another upgrade
            if(health == 1)
            {

                //define the values for the new scale
                newScale = new Vector3(2f, 2f, 2f);

                //changes the scale of the player
                transform.localScale += newScale;
                
                //set the amount of hearts the character has, adds one because one heart has been added to his health (the upgrade add one more heart)
                health += 1;
            }
        }
    }


    void LateUpdate()
    {
    }
}
