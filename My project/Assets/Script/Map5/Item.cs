using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Item : MonoBehaviour
{
    public GameObject home;
    public GameObject obs;
   
    void Start()
    {
    }

    void Update()
    { 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == home)
        {
            if(obs != null)
            {
                obs.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) //���̵�
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.G))//GetKey����ϸ� ������ �ٷ� �̵���
            {

                SceneManager.LoadScene(6);
            }
        }
    }
}
