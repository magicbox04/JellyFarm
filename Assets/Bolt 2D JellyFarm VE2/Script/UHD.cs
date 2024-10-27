using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UHD : MonoBehaviour
{

    public enum InfoType { jellatin, gold, option, jelly, plant }
    public InfoType type;
    Text myText;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }
    // Start is called before the first frame update
    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.jellatin:
                myText.text = string.Format("{0:F0}", GameManager.instance.jelatin);
                break;
            case InfoType.gold:
                myText.text = string.Format("{0:F0}", GameManager.instance.gold);
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
