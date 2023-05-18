using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MissonContorller : MonoBehaviour
{
    private GameObject leaf;
    public int leafCount = 0;
    public bool map5Clear = false;
    public bool clubClear= false ;
    public bool dropLeaf = false;
    public bool map3Btn1 = false;
    public bool map3Btn2 = false;
    public GameObject blind;
    private GameObject player1;
    private GameObject player2;
    private GameObject leafTrans;
    public int missonNum = 0;
    // Start is called before the first frame update
    void Start()
    { 
        DontDestroyOnLoad(gameObject); 
        leaf = gameObject.transform.GetChild(0).gameObject;
        leaf.SetActive(false);
    }
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player1 = GameObject.Find("Player1");
        if (GameObject.Find("Blind")) blind = GameObject.Find("Blind");
        if (GameObject.Find("LeafPos")) leafTrans = GameObject.Find("LeafPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (map3Btn1 == true && map3Btn2 == true)
        {
            dropLeaf = true;
            map3Btn1 = false;
            map3Btn2 = false;
            blind.SetActive(false);
        }
        if (map5Clear)
        {
            dropLeaf = true;
        }
        if ( dropLeaf==true)
        {
            if (leaf)
                LeafControl(); 
        }
    }
   
    void LeafControl()
    {
        leaf.transform.position = leafTrans.transform.position;
        leaf.SetActive(true);
        dropLeaf = false;

    }

}
