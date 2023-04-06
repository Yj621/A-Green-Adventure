using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonContorller : MonoBehaviour
{
    private GameObject leaf;
    public int leafCount = 0;
    public bool map5Clear = false;
    public bool clubClear= false ;
    private bool dropLeaf = false;
    public bool map3Btn1 = false;
    public bool map3Btn2 = false;

    private GameObject player1;
    private GameObject player2;
    private Vector3 leafTrans;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        leaf = gameObject.transform.GetChild(0).gameObject;
        leaf.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
       
        if (map3Btn1 == true && map3Btn2 == true)
        {
            dropLeaf = true;
            map3Btn1 = false;
            map3Btn2 = false;
        }
        if ( dropLeaf==true)
        {
            if (leaf)
                LeafControl(); 
        }
    }

    void LeafControl()
    {
        leafTrans = new Vector3(player1.transform.position.x, player1.transform.position.y+1f, 0f);
        leaf.transform.position = leafTrans;
        leaf.SetActive(true);
        leaf.GetComponent<Rigidbody2D>().AddForce(transform.up * 2f, ForceMode2D.Impulse);
        dropLeaf = false;
    }

}
