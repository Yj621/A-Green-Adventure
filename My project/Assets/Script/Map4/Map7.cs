using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Map7 : MonoBehaviour
{
    public Image imageToFade;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) //���̵�
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.G))//GetKey����ϸ� ������ �ٷ� �̵���
            {
                StartCoroutine(FadeOut());
                Invoke("Delay", 0.97f);                
            }
        }
    }

    void Delay()
    {
        SceneManager.LoadScene(9);
    }
    private IEnumerator FadeOut()
    {
        float duration = 1f;
        float startTime = Time.time;
        Vector3 startScale = new Vector3(imageToFade.rectTransform.localScale.x, imageToFade.rectTransform.localScale.y, 1f);

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            float alpha = Mathf.Lerp(1f, 0f, t);
            Vector3 scale = Vector3.Lerp(startScale, Vector3.zero, t);


            imageToFade.transform.localScale = scale;
            yield return null;
        }
        Destroy(imageToFade);
        Destroy(gameObject);
    }
}
