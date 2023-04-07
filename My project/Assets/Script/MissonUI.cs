using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissonUI : MonoBehaviour
{
    List<string> myList = new List<string>();
     private TextMeshProUGUI myTextMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        myTextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        myList.Add("Item 1");
        myList.Add("Item 2");
        myList.Add("Item 3");
    }

    // Update is called once per frame
    void Update()
    {
        myTextMeshProUGUI.text += myList[0] + "\n";
    }
}
