using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossGameContorl : MonoBehaviour
{
    public int bossHP;
    public int player1HP = 2;
    public int player2HP = 2;

    public GameObject[] player1HpBar;
    public GameObject[] player2HpBar;
    public Image bossBar;
    public bool PlayerWin = false;
    public bool Playerloose = false;

    public GameObject sun;
    public GameObject restart;

    public string lastSpawnedObjectTag;
    public string player1Touch;
    public string player2Touch;

    public int bossHppMinus = 10;
    void Start()
    {
        //���⿡�� ���� ü�� ���� �޾Ƽ� ���ϸ� �ɵ�
        bossHP = 100;

        //������ �¾� �̹��� �±� �ҷ�����
        sun = GameObject.Find("Sun");
        lastSpawnedObjectTag = sun.GetComponent<ObjectSpawner>().lastSpawnedObjectTag;
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾� �¸� ����
        if (bossBar.fillAmount < 0)
        {
            PlayerWin = true;
        }
        else if (player1HP <= 0 || player2HP <= 0) Playerloose = true;
        if (Playerloose)
        {
            Time.timeScale = 0;
            restart.SetActive(true);
        }
    }

    //���� ü�¹� ����
    public void BossHpBar()
    {
        //���� ü�� ���
        if (sun.GetComponent<ObjectSpawner>().lastSpawnedObjectTag == player1Touch || sun.GetComponent<ObjectSpawner>().lastSpawnedObjectTag == player2Touch) bossHP -= bossHppMinus;

        //�̹��� ���� ����
        bossBar.fillAmount = bossHP / 100f;
       
    }

    //�÷��̾�1 ü�¹� ����
    public void player1HpContorl()
    {
        if (sun.GetComponent<ObjectSpawner>().lastSpawnedObjectTag != player1Touch)
        {
            if (player1HP >= 0)
            {
                player1HpBar[player1HP].SetActive(false);
            }
            player1HP--;
        }
    }

    //�÷��̾�2 ü�¹� ����
    public void player2HpContorl()
    {
        if (sun.GetComponent<ObjectSpawner>().lastSpawnedObjectTag != player2Touch)
        {
            if(player2HP >= 0)
            {
                player2HpBar[player2HP].SetActive(false); 
            }
            player2HP--;
        }
    }
}
