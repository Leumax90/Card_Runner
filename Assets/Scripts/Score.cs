using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text myText;
   [SerializeField] public int scorePoints;
    public void scoreUpdate(int score)
    {
        scorePoints += score;
        myText.text = scorePoints.ToString("0");
    }
}
