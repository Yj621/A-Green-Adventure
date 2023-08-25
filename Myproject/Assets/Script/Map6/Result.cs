using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;
    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtScore = null;
    
    ScoreManager theScore;
    TimingManager theTiming;
    void Start()
    {
        theScore = FindObjectOfType<ScoreManager>();
        theTiming = FindObjectOfType<TimingManager>();
    }

    public void ShowResult()
    {
        goUI.SetActive(true);

        for(int i = 0; i<txtCount.Length; i++)
            txtCount[i].text = "0";

        txtScore.text = "0";
    }
}
