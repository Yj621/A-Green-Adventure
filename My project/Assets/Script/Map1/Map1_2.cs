using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Map1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
        // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D collision) //���̵�
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.G))//GetKey����ϸ� ������ �ٷ� �̵���
            {
                
                SceneManager.LoadScene(2);
            }
        }
    }
}

