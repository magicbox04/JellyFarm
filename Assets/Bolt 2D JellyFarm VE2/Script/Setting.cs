using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject settingsPanel;
    private bool isSettingsActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("ESC"))
        {
            Debug.Log("ESC Prseed");
            isSettingsActive = !isSettingsActive;
            settingsPanel.SetActive(isSettingsActive);
        }
        
    }
}
