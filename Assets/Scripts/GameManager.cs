using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int lavel = 1;
    private int score;
    public float speedTranslate;
    public float repeatTime;
    private Animator anim;
    private Text ColorText;
    public List<Color> colors;
    public Color targetColor;
    void Start()
    {
        // int timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timerIsRunning;

        //1 - repeat 0.43, transalte 5
        //2 - repeat 0.3, transalte 7.5
        //3 - repeat 0.2, transalte 10

        ColorText = GameObject.FindGameObjectWithTag("TextColor").GetComponent<Text>();
        anim = GameObject.FindGameObjectWithTag("Massage").GetComponent<Animator>();

        if (score <= 400)
        {
            targetColor = colors[Random.Range(0, 2)];
            ColorText.color = targetColor;

            if(targetColor == colors[0])
            {
                ColorText.text = "Red";
            }
            else if(targetColor == colors[1])
            {
                ColorText.text = "Green";
            }
            speedTranslate = 5f;
            repeatTime = 0.43f;
        }

        StartCoroutine(TargetColor());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator TargetColor()
    {

        while (true)
        {
            score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().scorePoints;

            if (score > 400 && score <= 800 && lavel==1)
            {
                targetColor = colors[2];
                ColorText.color = targetColor;
                ColorText.text = "Magenta";
                anim.SetTrigger("MesRevTrig");
 
                lavel++;
            }
            else if (score > 800 && score <= 1200 && lavel == 2)
            {
                targetColor = colors[3];
                ColorText.color = targetColor;
                ColorText.text = "Blue";
                anim.SetTrigger("MesRevTrig");

                lavel++;

                speedTranslate = 7.5f;
                repeatTime = 0.3f;
            }
            else if (score > 1200 && lavel == 3)
            {
                targetColor = colors[4];
                ColorText.color = targetColor;
                ColorText.text = "Yellow";
                anim.SetTrigger("MesRevTrig");

                lavel++;

                speedTranslate = 10f;
                repeatTime = 0.2f;
            }


            yield return null;
        }
    }
}