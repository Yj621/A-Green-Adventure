using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    private GameObject missonController;

    private void Start()
    {
        missonController = GameObject.Find("MissionController");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //태그를 비교해 태그에 머물러있을때 생기도록
        if (collision.gameObject.CompareTag("Map2"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Map3"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true); 
        }
        else if (collision.gameObject.CompareTag("Map1"))
        {
            if(missonController.GetComponent<MissonContorller>().missonNum == 1)
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Map5"))
        {
            if (missonController.GetComponent<MissonContorller>().missonNum == 5)
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Map6"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Map7"))
        {
            if (missonController.GetComponent<MissonContorller>().missonNum == 7)
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //태그를 비교해 태그를 벗어날때 없어지도록
        if (collision.gameObject.CompareTag("Map2"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Map3"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Map1"))
        {
            if (missonController.GetComponent<MissonContorller>().missonNum == 1)
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Map5"))
        {
            if (missonController.GetComponent<MissonContorller>().missonNum == 5)
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Map6"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Map7"))
        {
            if (missonController.GetComponent<MissonContorller>().missonNum == 7)
                collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}