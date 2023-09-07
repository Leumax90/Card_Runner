using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rows : MonoBehaviour
{

    public List<GameObject> row;
   // private int level;
    private Transform transRow;
    [SerializeField] public Transform startPosition;
    // Start is called before the first frame update
    void Start()
    {

        transRow = GetComponent<Transform>();
        //  level = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().lavel;
        StartCoroutine(RandomActive());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator RandomActive()
    {
        int ractangle;
        for (int i = 0; i <= 1; i++)
        {
            ractangle = Random.Range(0, row.Count);
            row[ractangle].SetActive(true);
        }


        while (true)
        {
            
            transRow.Translate(new Vector2(0, -2) * Time.deltaTime * 2);

            Vector2 bottom = new Vector2(0, -18);
           
            if (Vector2.Distance(transRow.position, bottom) < 2)
            {
              //  Debug.Log(Vector2.Distance(transRow.position, bottom));
                transRow.position = startPosition.position;

                for (int i = 0; i< row.Count; i++)
                {
                    row[i].SetActive(false);
                }

                for (int i = 0; i <= 1; i++)
                {
                    ractangle = Random.Range(0, row.Count);
                    row[ractangle].SetActive(true);
                }
            }
            yield return null;
        }
    }
}
