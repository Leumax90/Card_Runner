using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{
    public GameObject Ok;
    public GameObject Lose;
    public AudioSource audioSource;
    public AudioClip oneTouchSound;
    public ParticleSystem Stars;
    public ParticleSystem LightRing;
    private Animator anim;
    private SpriteRenderer selfColor;
    private Color targetCol;
    private bool rotateDone = false;
    private int scoreValue;
  //  private float speed;
    public Collider2D col;
    //  private int score;
    void Start()
    {
        anim = GetComponent<Animator>();
        selfColor = GetComponent<SpriteRenderer>();
        targetCol = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().targetColor;
       // speed = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().speedTranslate;

    }
   
    void Update()
    {
        // Touch Controller

        transform.Translate(new Vector2(0, -1) * Time.deltaTime * 7.5f);

        for (int i = 0; i < Input.touchCount; i++)
        {
            Color colorFade = selfColor.color;
            bool timeRun = FindObjectOfType<Timer>().timerIsRunning;

            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (col == Physics2D.OverlapPoint(touchPos) && !rotateDone && timeRun)
            {

                    rotateDone = true;

                    if (selfColor.color == targetCol)
                    {
                        audioSource.PlayOneShot(oneTouchSound);
                        Stars.Play();
                        LightRing.Play();

                        // Добавляем баллы
                        scoreValue = 10;
                        FindObjectOfType<Score>().scoreUpdate(scoreValue);

                        //        timeRemein = +1;      сделать SendMasage в Timer

                        // Включаем Ок, делаем прозрачной карточку
                        colorFade.a = 0.4f;
                        selfColor.color = colorFade;
                        Ok.SetActive(true);

                        //Делаем вращение, через аниматор
                        anim.SetTrigger("rott");
                        anim.SetBool("rot", true);
                    }
                    else
                    {
                        //        timeRemein = -2;      сделать SendMasage в Timer

                        // Включаем Lose, делаем прозрачной карточку
                        colorFade.a = 0.4f;
                        selfColor.color = colorFade;
                        Lose.SetActive(true);

                        //Делаем вращение, через аниматор
                        anim.SetTrigger("vibroo");
                        anim.SetBool("vibro", true);

                    }
                }
        }
      
    }

    // Mouse Contrller

      void OnMouseOver()
      {
        Color colorFade = selfColor.color;
        bool timeRun = FindObjectOfType<Timer>().timerIsRunning;
    //  float timeRemein = FindObjectOfType<Timer>().timeRemaining;

        if (Input.GetMouseButtonDown(0) && !rotateDone && timeRun)
          {
            rotateDone = true;

            if (selfColor.color == targetCol)
            {
                audioSource.PlayOneShot(oneTouchSound);
                Stars.Play();
                LightRing.Play();

                // Добавляем баллы
                scoreValue = 10;
                FindObjectOfType<Score>().scoreUpdate(scoreValue);

                //        timeRemein = +1;      сделать SendMasage в Timer

                // Включаем Ок, делаем прозрачной карточку
                colorFade.a = 0.4f;
                selfColor.color = colorFade;
                Ok.SetActive(true);

                //Делаем вращение, через аниматор
                anim.SetTrigger("rott");
                anim.SetBool("rot", true);
            } 
            else
            {
                //        timeRemein = -2;      сделать SendMasage в Timer

                // Включаем Lose, делаем прозрачной карточку
                colorFade.a = 0.4f;
                selfColor.color = colorFade;
                Lose.SetActive(true);

                //Делаем вращение, через аниматор
                anim.SetTrigger("vibroo");
                anim.SetBool("vibro", true);

            }
        }
      }

    


}