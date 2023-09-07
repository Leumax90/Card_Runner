using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
   // private float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y / 1.35f;
       // speed = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().speedTranslate;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -1) * Time.deltaTime * 7.5f);
        if (transform.position.y < startPos.y - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
