using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Control")]
    bool isLive;
    public Sprite[] jellySpriteList;
    public string[] jellyNameList;
    public int[] jellyJelatinList;
    public int[] jellyGoldList;
    public RuntimeAnimatorController[] animControl;
    [Header("# Player Info")]
    public int jelatin;
    public int gold;

    [Header("# Game Object")]
    public GameObject settingsPanel;
    private bool isSettingsActive = false;
    


    private void Awake()
    {
        isLive = true;
        instance = this;
        Application.targetFrameRate = 60;
        jelatin = PlayerPrefs.GetInt("jelatin");
        gold = PlayerPrefs.GetInt("gold");
    }  

    void Update()
    {
        PlayerPrefs.SetInt("jelatin", jelatin);
        PlayerPrefs.SetInt("gold", gold);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isSettingsActive = !isSettingsActive;
            settingsPanel.SetActive(isSettingsActive);
            if (isSettingsActive)
            {
                Stop();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
