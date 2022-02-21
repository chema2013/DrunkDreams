using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_behaviour : MonoBehaviour
{
    //array with the third sprite, so it can be called later
    public GameObject[] thirdAnim = new GameObject[1];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks iif the gameobject is called ....(clone) which means it isn't the original and can be destroyed after it has completed the animation
        if(GameObject.Find("Explosion(Clone)") && thirdAnim[0].activeSelf == true)
        {
            Destroy(gameObject);
        }
    }
}
