using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MapSwitching : MonoBehaviour
{
    public Image imageToFadeOut;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Map1"))
        {
            if (Input.GetKey(KeyCode.G))//GetKey사용하면 누를때 바로 이동됨
            {
                imageToFadeOut.gameObject.SetActive(true);
                StartCoroutine(FadeOut());
                Invoke("LoadMap1_2", 0.97f);
            }
        }
        if (collision.gameObject.CompareTag("Map2"))
        {
            if (Input.GetKey(KeyCode.G))
            {
                imageToFadeOut.gameObject.SetActive(true);
                StartCoroutine(FadeOut());
                Invoke("LoadMap2", 0.97f);
            }
        }
        if (collision.gameObject.CompareTag("Map3"))
        {
            if (Input.GetKey(KeyCode.G))
            {
                imageToFadeOut.gameObject.SetActive(true);
                StartCoroutine(FadeOut());
                Invoke("LoadMap3", 0.97f);
            }
        }
        if (collision.gameObject.CompareTag("Map4_2"))
        {
            imageToFadeOut.gameObject.SetActive(true);
            StartCoroutine(FadeOut());
               Invoke("LoadMap4_2", 0.97f);
            
        }
        if (collision.gameObject.CompareTag("Map4_3"))
        {
           if (Input.GetKey(KeyCode.G))
           {
                imageToFadeOut.gameObject.SetActive(true);
                StartCoroutine(FadeOut());
               Invoke("LoadMap4_3", 0.97f);
           }
        }
        if (collision.gameObject.CompareTag("Map4_4"))
        {
           if (Input.GetKey(KeyCode.G))
           {
                imageToFadeOut.gameObject.SetActive(true);
                StartCoroutine(FadeOut());
               Invoke("LoadMap4_4", 0.97f);
           }
        }        
        if (collision.gameObject.CompareTag("Map5"))
        {
           if (Input.GetKey(KeyCode.G))
           {
               StartCoroutine(FadeOut());
               Invoke("LoadMap5", 0.97f);
           }
        }

        if (collision.gameObject.CompareTag("Map6"))
        {
           if (Input.GetKey(KeyCode.G))
           {
                imageToFadeOut.gameObject.SetActive(true);
                StartCoroutine(FadeOut());
               Invoke("LoadMap6", 0.97f);
           }
        }
        if (collision.gameObject.CompareTag("Map7"))
        {
           if (Input.GetKey(KeyCode.G))
           {
                imageToFadeOut.gameObject.SetActive(true);
                StartCoroutine(FadeOut());
               Invoke("LoadMap7", 0.97f);
           }
        }
        if (collision.gameObject.CompareTag("Map8"))
        {
            imageToFadeOut.gameObject.SetActive(true);
            StartCoroutine(FadeOut());
           Invoke("LoadMap8", 0.97f);

        }
    }

    private void LoadMap1_2()
    {
        Debug.Log(GameObject.Find("MissionController").GetComponent<MissonContorller>().missonNum);
        SceneManager.LoadScene(2);
    }
    private void LoadMap2()
    {
        SceneManager.LoadScene(3);
        Debug.Log(GameObject.Find("MissionController").GetComponent<MissonContorller>().missonNum);
    }

    private void LoadMap4_2()
    {
        SceneManager.LoadScene(6);
    }

    private void LoadMap4_3()
    {
        SceneManager.LoadScene(7);
    }

    private void LoadMap4_4()
    {
        SceneManager.LoadScene(8);
    }
    private void LoadMap5()
    {
        SceneManager.LoadScene(9);
    }
    private void LoadMap6()
    {
        SceneManager.LoadScene(10);
    }
    private void LoadMap7()
    {
        SceneManager.LoadScene(11);
    }
    private void LoadMap8()
    {
        SceneManager.LoadScene(12);
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

