using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public GameObject heartObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = heartObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
