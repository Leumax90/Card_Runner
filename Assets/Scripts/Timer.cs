using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning;
    public Text timeText;
    public GameObject resume;
    public GameObject Menu;
    public GameObject background;
    public GameObject massage;
    public GameObject top;
   // public GameObject score;
    public GameObject overText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                
                Menu.SetActive(true);
                overText.SetActive(true);
                resume.SetActive(false);
                massage.SetActive(false);
                top.transform.localScale = new Vector3();
               // score.transform.localScale = new Vector3(1,1,1);
                background.GetComponent<Background>().enabled = false;

                timeRemaining = 0;
                timerIsRunning = false;

            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}