using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool move = false;
    private GameObject player;
    public GameObject homePosition; //도착지점

    void Start()
    {
    }

    void Update()
    {
        if(move == true)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 objectPosition = gameObject.transform.position;

            //도착 지점과의 거리 계산
            float distance = Vector2.Distance(objectPosition, homePosition.transform.position);

            if (distance > 1f)
            {
                //player 따라가기
                objectPosition = Vector2.MoveTowards(objectPosition, playerPosition, 5 * Time.deltaTime);
            }
            else
            {
               //오브젝트 위치 고정
                objectPosition = homePosition.transform.position;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            // 오브젝트 위치 수정
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
