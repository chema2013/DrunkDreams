using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //variable to store the number of points the character gets from the screws
    private static int score;

    //made a public variable to store the text component that is going to change
    public Text scoreString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calls the public static variable defined in the characterBehaviour script and makes it equal to the score variable
        score = CharacterBehaviour.points;

        //change string in the text component with the score value
        scoreString.text = score.ToString();


    }
}
