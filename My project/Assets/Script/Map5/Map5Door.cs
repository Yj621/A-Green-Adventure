using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Map5Door : MonoBehaviour
{
    public bool glassHome = false;
    public bool petHome = false;
    public bool paperHome = false;

    public int homeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) //씬이동
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (homeCount == 3)
            {
                if (Input.GetKey(KeyCode.G))//GetKey사용하면 누를때 바로 이동됨
                {
                    SceneManager.LoadScene(6);
                }
            }

        }
    }
}
