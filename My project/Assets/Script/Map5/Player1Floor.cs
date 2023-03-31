using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Floor : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == player.gameObject)
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
