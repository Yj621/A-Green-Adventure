using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map1_2 : MonoBehaviour
{
    public Image imageToFadeOut;
    private GameObject Map2_icon;
    // Start is called before the first frame update
    void Start()
    {
        Map2_icon = GameObject.Find("Map2Icon");
        Map2_icon.SetActive(false);
    }
        // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision) //���̵�
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             Map2_icon.SetActive(true);
            if (Input.GetKey(KeyCode.G))//GetKey����ϸ� ������ �ٷ� �̵���
            {
                StartCoroutine(FadeOut());
                Invoke("Delay", 0.97f);
                
            }
        }
    }
    void Delay()
    {
        SceneManager.LoadScene(4);
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        Map2_icon.SetActive(false);
    }
}

