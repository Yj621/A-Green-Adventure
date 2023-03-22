using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueSystem : MonoBehaviour
{
    public Text name;
    public Text sentence;
   // public GameObject Chat;

    Queue<string> sentences = new Queue<string>();

    public void Begin(Dialogue info)
    {
        sentences.Clear(); //�ʱ�ȭ
        name.text = info.name;

        foreach (var sentence in info.sentences) //���� ���� �ݺ���
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }
    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
            return;

        }
        sentence.text = sentences.Dequeue(); //�������� �ֱ�
    }

    private void End()
    {
        GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(false);

    }
}
