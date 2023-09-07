using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float height;
    public float width;
    public GameObject cardTile;
    public List<GameObject> positions;
    private List<Color> colors;
    private int score;
    private bool timer;
    private float delayTime = 2.2f;
    private float repeatTime = 0.3f;



    void Start()
    {
        colors = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().colors;
        // repeatTime = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().repeatTime;

        InvokeRepeating("spawner", delayTime, repeatTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(width, height, 0));
    }
    // Update is called once per frame
    void Update()
    {
 
    }

    void spawner()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().scorePoints;
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timerIsRunning;
        // for (int i = 0; i <= 1; i++)
        //  {
        if (timer) {
            int card_1 = Random.Range(0, positions.Count);
            int card_2 = Random.Range(0, positions.Count);

            GameObject newCard_1 = Instantiate(cardTile, positions[card_1].transform.position, Quaternion.identity);
            newCard_1.transform.parent = positions[card_1].transform;

            if (score <= 400)
            {
                newCard_1.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, 2)];
            }
            else if (score > 400 && score <= 800)
            {
                newCard_1.GetComponent<SpriteRenderer>().color = colors[Random.Range(1, 3)];
            }
            else if (score > 800 && score <= 1200)
            {
                newCard_1.GetComponent<SpriteRenderer>().color = colors[Random.Range(2, 4)];
            }
            else if (score > 1200)
            {
                newCard_1.GetComponent<SpriteRenderer>().color = colors[Random.Range(3, 5)];
            }
      
          
            if (card_1 != card_2)
            {
                GameObject newCard_2 = Instantiate(cardTile, positions[card_2].transform.position, Quaternion.identity);
                newCard_2.transform.parent = positions[card_2].transform;

                if (score <= 400)
                {
                    newCard_2.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, 2)];
                }
                else if (score > 400 && score <= 800)
                {
                    newCard_2.GetComponent<SpriteRenderer>().color = colors[Random.Range(1, 3)];
                }
                else if (score > 800 && score <= 1200)
                {
                    newCard_2.GetComponent<SpriteRenderer>().color = colors[Random.Range(2, 4)];
                }
                else if (score > 1200)
                {
                    newCard_2.GetComponent<SpriteRenderer>().color = colors[Random.Range(3, 5)];
                }
            }
        }
        //  }


        /*   foreach (Transform child in transform)
           {
               GameObject card = Instantiate(cardTile, child.position, Quaternion.identity);
               card.transform.parent = child;
             //  child.GetChild(1);
           }*/
    }
}
