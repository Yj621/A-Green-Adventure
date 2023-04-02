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
    //���� ������ ������
    private static string relativePath = "Python/weather.txt";
    //�����η� ��ȯ
    private static string absolutePath = Path.GetFullPath(relativePath);


    void Start()
    {
        txt = GetComponent<TextMeshPro>();

        StartCoroutine(GetValue());
    }


    // �ֱ������� ���� ������ �˻��Ͽ� ���� �������� �Լ�
    IEnumerator GetValue()
    {
        while (true)
        {
            // ���� ���� �б�
            string valueString = File.ReadAllText(absolutePath);

            // ���� �����ϴ� �ڵ� �ۼ�
            txt.text = valueString;
            UnityEngine.Debug.Log(valueString);

            // 1�� ���
            yield return new WaitForSeconds(1f);
        }
    }
}
