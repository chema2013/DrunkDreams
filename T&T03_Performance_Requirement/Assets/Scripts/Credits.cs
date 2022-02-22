using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //makes the script a coroutine
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waiter()
    {
        
        //waits 1 second before making another action
        yield return new WaitForSeconds(10);
        
        //once the time is completed it destroys the object
        SceneManager.LoadScene("MainMenu");
    }
}
