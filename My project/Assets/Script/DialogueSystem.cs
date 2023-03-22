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
        sentences.Clear(); //초기화
        name.text = info.name;

        foreach (var sentence in info.sentences) //문장 돌기 반복문
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
        sentence.text = sentences.Dequeue(); //다음문장 넣기
    }

    private void End()
    {
        GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(false);

    }
}
