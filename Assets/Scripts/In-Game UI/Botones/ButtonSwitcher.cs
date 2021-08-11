using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitcher : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;
    bool state = true;
    public void switcher()
    {
        if(state)
        {
            state = false;
            GetComponent<Image>().sprite = Off;
        }
        else
        {
            state = true;
            GetComponent<Image>().sprite = On;
        }
    }
}
