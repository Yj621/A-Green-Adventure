using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public Image imageToFadeIn;

    private void Start()
    {
        imageToFadeIn.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float duration = 1f;
        float startTime = Time.time;
        Vector3 startScale = new Vector3(imageToFadeIn.rectTransform.localScale.x, imageToFadeIn.rectTransform.localScale.y, 1f);

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            float alpha = Mathf.Lerp(1f, 0f, t);
            Vector3 scale = Vector3.Lerp(startScale, new Vector3(1200,500,0), t);

            imageToFadeIn.transform.localScale = scale;
            yield return null;
        }

        Destroy(imageToFadeIn);
        Destroy(gameObject);
    }

}