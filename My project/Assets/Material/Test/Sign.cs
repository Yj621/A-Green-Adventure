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
    // ���� �ҷ��� ���� ���
    //��������
    string filePath = "C:\\Users\\Excellent_Summer\\Desktop\\git\\Kp-23-1\\My project\\Python\\weather.txt";

    // �ֱ������� ���� ������ �˻��Ͽ� ���� �������� �Լ�
    IEnumerator GetValue()
    {
        while (true)
        {
            // ���� ���� �б�
            string valueString = File.ReadAllText(filePath);

            // ���� �����ϴ� �ڵ� �ۼ�
            txt.text = valueString;
            UnityEngine.Debug.Log(valueString);

            // 1�� ���
            yield return new WaitForSeconds(1f);
        }
    }
}
