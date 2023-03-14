using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map3_1 : MonoBehaviour
{


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Map()
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Player2")
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
