using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using System.IO;
using UnityEngine.UI;


public class Sign : MonoBehaviour
{
    public TextMesh txt;
    void Start()
    {
        txt = GetComponent<TextMesh>();

        StartCoroutine(GetValue());
    }
    // 값을 불러올 파일 경로
    //날씨정보
    string filePath = "C:\\Users\\Excellent_Summer\\Desktop\\git\\Kp-23-1\\My project\\Python\\weather.txt";

    // 주기적으로 파일 내용을 검색하여 값을 가져오는 함수
    IEnumerator GetValue()
    {
        while (true)
        {
            // 파일 내용 읽기
            string valueString = File.ReadAllText(filePath);

            // 값을 적용하는 코드 작성
            txt.text = valueString;
            UnityEngine.Debug.Log(valueString);

            // 1초 대기
            yield return new WaitForSeconds(1f);
        }
    }
}
