using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map1Switching : MonoBehaviour
{
    public Image imageToFadeOut;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Map2"))
        {
            if (Input.GetKey(KeyCode.G))//GetKey사용하면 누를때 바로 이동됨
            {
                StartCoroutine(FadeOut());
                Invoke("LoadMap2", 0.97f);
            }
        }
        
        if (collision.gameObject.CompareTag("Map3"))
        {
            if (Input.GetKey(KeyCode.G))
            {
                StartCoroutine(FadeOut());
                Invoke("LoadMap3", 0.97f);
            }
        }
    }

    private void LoadMap2()
    {
        SceneManager.LoadScene(3);
    }

    private void LoadMap3()
    {
        SceneManager.LoadScene(4);
    }

    private IEnumerator FadeOut()
    {
        //페이드인 페이드아웃
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
