using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    //variable that makes reference to the gameobject  that is going to be the parent of this gameObject
    public GameObject heartObject;
    // Start is called before the first frame update
    void Start()
    {
        //changed the parent of every heart that will be spawned
        gameObject.transform.parent = heartObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
