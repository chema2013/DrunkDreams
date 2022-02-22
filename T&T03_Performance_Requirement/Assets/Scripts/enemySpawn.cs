using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{

    public GameObject[] enemiesObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //checks if it collided with the character
        if(other.gameObject.CompareTag("character"))
        {
            int objects = enemiesObj.Length;
            for(int i = 0; i < objects; i++)
            {
                enemiesObj[i].SetActive(true);
            }

            //then it destroys this spawner
            Destroy(gameObject);
        }
    }
}
