using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject home;

    void Start()
    {
    }

    void Update()
    { 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == home)
        {

        }
    }
}
