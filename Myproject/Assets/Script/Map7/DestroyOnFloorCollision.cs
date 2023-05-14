using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOnFloorCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject); // 충돌한 오브젝트를 파괴합니다. 
        }
    }

}
