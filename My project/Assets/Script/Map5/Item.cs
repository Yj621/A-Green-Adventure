using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject home;
    public GameObject obs;
    public GameObject door;
    private int doorHomeCount;
    void Start()
    {
    }

    void Update()
    { 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject == home)
            {
                door.GetComponent<Map5Door>().homeCount += 1;

                if (obs != null)
                {
                    obs.SetActive(false);
                }
            }

    }

 
}
