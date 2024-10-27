using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pannels : MonoBehaviour
{
    public GameObject otherPanel;
    public Button button;
    Animator anim;
    Sprite buttonSprite;


    bool isActive = false;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        buttonSprite = button.image.sprite;
    }

    public void onClick()
    {
        Pannels otherPanelScript = otherPanel.GetComponent<Pannels>();
        if (otherPanelScript.isActive)
        {
            otherPanelScript.isActive = false;
            otherPanelScript.anim.SetTrigger("onHide");
            otherPanelScript.button.image.sprite = otherPanelScript.buttonSprite;
        }
        isActive = !isActive;
        if (isActive)
        {
            anim.SetTrigger("onShow");
            button.image.sprite = button.spriteState.highlightedSprite;
        }
        else
        {
            anim.SetTrigger("onHide");
            button.image.sprite = buttonSprite;
        }
    }

}
