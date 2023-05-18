using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Map3 : MonoBehaviour
{
    public bool getLeaf = false;
    public Image imageToFadeOut;

    void Update()
    {
        if (getLeaf) 
        {
            StartCoroutine(FadeOut());
            Invoke("Delay", 0.97f);
        }
    }
    void Delay()
    {
        //GameObject.Find("MissionController").GetComponent<MissonContorller>().missonNum++;
        SceneManager.LoadScene(5);
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
