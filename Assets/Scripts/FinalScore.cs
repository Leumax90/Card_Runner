using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text finalScore;
    public GameObject score;
    void Start()
    {        
            finalScore.text = score.GetComponent<Score>().myText.text;
    }
}
