using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    //creates the event for the screenshake that will be called in a coroutine
    public IEnumerator Shake (float duration, float magnitude) //duration and strength of the shake
    {
        //initial position of the camera
        Vector3 originalPosition = transform.localPosition;

        //how much time it has been shaking
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            //setting the movement of the camera
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            //changes the position of the camera
            transform.localPosition = new Vector3(x, y, originalPosition.z);

            //adds to the elapsed value so it stops shaking
            elapsed += Time.deltaTime;

            //makes sure to wait until the next frame
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
