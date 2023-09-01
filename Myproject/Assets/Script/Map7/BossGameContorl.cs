using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossGameContorl : MonoBehaviour
{
    private GameObject missonController;
    public Image imageToFadeOut;

    public int bossHP;
    public int player1HP = 2;
    public int player2HP = 2;

    public GameObject[] player1HpBar;
    public GameObject[] player2HpBar;
    public Image bossBar;
    public bool PlayerWin = false;
    public bool Playerloose = false;

    public GameObject leaf;
    public GameObject sun;
    public GameObject restart;
    public GameObject gameUI;
    public GameObject gameBackground;
    public GameObject gameSystem;

    public string lastSpawnedObjectTag;
    public string player1Touch;
    public string player2Touch;

    public int bossHppMinus = 10;
    void Start()
    {
        missonController = GameObject.Find("MissionController");

        //���⿡�� ���� ü�� ���� �޾Ƽ� ���ϸ� �ɵ�
        bossHP = 100;

        //������ �¾� �̹��� �±� �ҷ�����
        sun = GameObject.Find("Sun");
        lastSpawnedObjectTag = sun.GetComponent<ObjectSpawner>().lastSpawnedObjectTag;

        sun.SetActive(false);
        gameUI.SetActive(false);
        gameSystem.SetActive(false);
        gameBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (missonController.GetComponent<MissonContorller>().leafCount == 3)
        {
            imageToFadeOut.gameObject.SetActive(true);
            StartCoroutine(FadeOut());
            Invoke("LoadMap9", 0.97f);
        }
        if (missonController.GetComponent<MissonContorller>().missonNum == 9)
        {
            gameUI.SetActive(true);
            gameSystem.SetActive(true);
            sun.SetActive(true);
            gameBackground.SetActive(true);
        }
        //�÷��̾� �¸� ����
        if (bossBar.fillAmount <= 0)
        {
            PlayerWin = true;
        }
        else if (player1HP < 0 || player2HP < 0) Playerloose = true;
        if (Playerloose)
        {
            Time.timeScale = 0;
            restart.SetActive(true);
        }
        if (PlayerWin == true)
        {
            leaf.SetActive(true);
            PlayerWin = false;
            gameUI.SetActive(false);
            gameSystem.SetActive(false);
            sun.SetActive(false);
            gameBackground.SetActive(false);
            bossBar.fillAmount = 1;
            missonController.GetComponent<MissonContorller>().missonNum = 11;
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

    private void LoadMap9()
    {
        SceneManager.LoadScene(13);
    }
    private IEnumerator FadeOut()
    {
        float duration = 1f;
        float startTime = Time.time;
        Vector3 startScale = new Vector3(imageToFadeOut.rectTransform.localScale.x, imageToFadeOut.rectTransform.localScale.y, 1f);

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            float alpha = Mathf.Lerp(1f, 0f, t);
            Vector3 scale = Vector3.Lerp(startScale, Vector3.zero, t);


            imageToFadeOut.transform.localScale = scale;
            yield return null;
        }
        Destroy(imageToFadeOut);
        Destroy(gameObject);
    }
}
