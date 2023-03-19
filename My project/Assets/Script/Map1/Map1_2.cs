using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Map1 : MonoBehaviour
{
    private GameObject H_icon;

    // Start is called before the first frame update
    void Start()
    {
        H_icon = GameObject.Find("HouseIcon");
        H_icon.SetActive(false);
    }
        // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D collision) //씬이동
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            H_icon.SetActive(true);
            if (Input.GetKey(KeyCode.G))//GetKey사용하면 누를때 바로 이동됨
            { 
                SceneManager.LoadScene(2);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        H_icon.SetActive(false);
    }
}

