using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Map1_2 : MonoBehaviour
{
    private GameObject Map2_icon;
    // Start is called before the first frame update
    void Start()
    {
        Map2_icon = GameObject.Find("Map2Icon");
        Map2_icon.SetActive(false);
    }
        // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision) //���̵�
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             Map2_icon.SetActive(true);
            if (Input.GetKey(KeyCode.G))//GetKey����ϸ� ������ �ٷ� �̵���
            {  
                SceneManager.LoadScene(4);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Map2_icon.SetActive(false);
    }
}

