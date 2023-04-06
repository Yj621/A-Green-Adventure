using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Map5Door : MonoBehaviour
{
    public Image imageToFadeOut;

    public bool glassHome = false;
    public bool petHome = false;
    public bool paperHome = false;

    public int homeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(homeCount == 3)
        {
            GameObject.Find("MissionController").GetComponent<MissonContorller>().map5Clear = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) //씬이동
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (homeCount == 3)
            {
                if (Input.GetKey(KeyCode.G))//GetKey사용하면 누를때 바로 이동됨
                {
                    StartCoroutine(FadeOut());
                    Invoke("Delay", 0.97f);
                }
            }

        }
    }

    void Delay()
    {
        SceneManager.LoadScene(6);
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
