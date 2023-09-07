using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rectangle : MonoBehaviour
{
    public Image front;
    public Image back;
    private Transform parentTransform;
    private Animator anim;
    Quaternion Target = Quaternion.Euler(0f, 180f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        parentTransform = transform.parent;
        anim = GetComponent<Animator>();


   //     !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        Quaternion rot = gameObject.transform.rotation;
        rot.y = 5f;
        gameObject.transform.rotation = rot;


    //    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



    }

    // Update is called once per frame
    void Update()
    {
     /*      if(Input.GetMouseButtonDown(0))
           {

           // Quaternion Target = Quaternion.Euler(0f, 180f, 0f);

            //        transform.rotation = Quaternion.Slerp(transform.rotation, Target, 10 * Time.deltaTime);



                    // StartCoroutine(RotateCard());
                    anim.SetTrigger("rott");
             anim.SetBool("rot", true);            
           }
     */
        if (transform.rotation == Target)
        {
            StopCoroutine(RotateCard());
        }

    }

    void OnMouseOver()
    {
        // anim.SetTrigger("rott");
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(RotateCard());
             anim.SetTrigger("rott");
             anim.SetBool("rot", true);
            // 

          /*  Quaternion Target = Quaternion.Euler(0f, 180f, 0f);

            
            while (transform.rotation != Target)
            {



                transform.rotation = Quaternion.Slerp(transform.rotation, Target, 10 * Time.deltaTime);

                /* if (Quaternion.Angle(transform.rotation, Target) <= 90f)
                 {
                     front.enabled = true;
                     back.enabled = false;
                 }*/


              /*    if (Vector2.Distance(parentTransform.position, new Vector2(0, 0)) > 4)
                  {
                       front.enabled = false;
                       back.enabled = true;
                      transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                  } 
                if (transform.rotation == Target)
                {
                    break;
                }
                
            }*/

        }
    } 
    IEnumerator RotateCard()
    {
        

        while (transform.rotation != Target)
        {
            Debug.Log(Time.deltaTime);

                transform.rotation = Quaternion.Slerp(transform.rotation, Target, 10 * Time.deltaTime);

               /* if (Quaternion.Angle(transform.rotation, Target) <= 90f)
                {
                    front.enabled = true;
                    back.enabled = false;
                }*/
            

            yield return null;

          /*  if (Vector2.Distance(parentTransform.position, new Vector2(0, 0)) > 4)
            {
                front.enabled = false;
                back.enabled = true;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            */
           
            
        }

       /* while(true)
        {
            Debug.Log("sadasdasd");
            if (Vector2.Distance(parentTransform.position, new Vector2(0, 0)) > 400)
            {
                front.enabled = false;
                back.enabled = true;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            yield return null;
        }*/
    }
}
