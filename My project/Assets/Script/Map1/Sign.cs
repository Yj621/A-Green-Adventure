using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Sign : MonoBehaviour
{
    private TextMeshPro txt;
    //날씨 정보를 가져옴
    private static string relativePath = "Python/weather.txt";
    //절대경로로 변환
    private static string absolutePath = Path.GetFullPath(relativePath);


    void Start()
    {
        txt = GetComponent<TextMeshPro>();

        StartCoroutine(GetValue());
    }


    // 주기적으로 파일 내용을 검색하여 값을 가져오는 함수
    IEnumerator GetValue()
    {
        while (true)
        {
            // 파일 내용 읽기
            string valueString = File.ReadAllText(absolutePath);

            // 값을 적용하는 코드 작성
            txt.text = valueString;
            UnityEngine.Debug.Log(valueString);

            // 1초 대기
            yield return new WaitForSeconds(1f);
        }
    }
}
