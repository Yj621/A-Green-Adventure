using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using System.IO;
using UnityEngine.UI;


public class time : MonoBehaviour
{
    public TextMesh txt2;
    void Start()
    {
        txt2 = GetComponent<TextMesh>();

        StartCoroutine(GetValue());
    }
    // ���� �ҷ��� ���� ���
    //��������
    string filePath = "C:\\Users\\Excellent_Summer\\Unity Python\\time.txt";

    // �ֱ������� ���� ������ �˻��Ͽ� ���� �������� �Լ�
    IEnumerator GetValue()
    {
        while (true)
        {
            // ���� ���� �б�
            string valueString = File.ReadAllText(filePath);

            // ���� �����ϴ� �ڵ� �ۼ�
            txt2.text = valueString;
            UnityEngine.Debug.Log(valueString);

            // 1�� ���
            yield return new WaitForSeconds(1f);
        }
    }
}
