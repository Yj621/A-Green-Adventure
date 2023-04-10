using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoFloor : MonoBehaviour
{

    private int ride = 0;
    private bool left = true;
    // Start is called before the first frame update
    void Start()
    {
        left = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ride == 2)
        {
            Direction();
            if(left == true)
            {
                Vector2 pos = new Vector2(gameObject.transform.position.x - 1f, gameObject.transform.position.y);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, pos, 2f * Time.deltaTime);
            }
                
            if(left == false)
            {
                Vector2 pos = new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y);
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, pos, 2f * Time.deltaTime);
            }


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ride++;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ride--;
        }
    }

   void Direction()
    {
        if(gameObject.transform.position.x < -2f)
        {
            left =  false;
        }
        if (gameObject.transform.position.x >= 5.3f) left = true;
    }
}
