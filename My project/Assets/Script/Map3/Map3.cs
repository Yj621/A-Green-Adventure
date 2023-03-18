using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map3 : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool map3 = (GameObject.Find("Player1").GetComponent<Map3Player>().isBtn1==true)&& 
            (GameObject.Find("Player2").GetComponent<Map3Player2>().isBtn2 == true);
        if (map3 == true)
        {
            SceneManager.LoadScene(5);
        }
    }
}
