using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Score : MonoBehaviour
{
    private int scorevalue;
    public Text scoretext;
    private void Start()
    {
        scoretext.text = "Score: " + scorevalue;
    }
    public void AddPoints(int points)
    {
        scorevalue += points;
        scoretext.text = "Score: " + scorevalue;
    }

    public void ReducePoitns(int points)
    {
        scorevalue -= points;
        scoretext.text = "Score: " + scorevalue;
    }
 
    public int GetScore()
    {
        return scorevalue;
    }
}
