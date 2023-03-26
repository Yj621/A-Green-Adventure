using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool move = false;
    private GameObject player;
    public GameObject homePosition; //��������

    void Start()
    {
    }

    void Update()
    {
        if(move == true)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 objectPosition = gameObject.transform.position;

            //���� �������� �Ÿ� ���
            float distance = Vector2.Distance(objectPosition, homePosition.transform.position);

            if (distance > 1f)
            {
                //player ���󰡱�
                objectPosition = Vector2.MoveTowards(objectPosition, playerPosition, 5 * Time.deltaTime);
            }
            else
            {
               //������Ʈ ��ġ ����
                objectPosition = homePosition.transform.position;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            // ������Ʈ ��ġ ����
            gameObject.transform.position = objectPosition;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            move = true;
            player = collision.gameObject;
        }

    }

}
