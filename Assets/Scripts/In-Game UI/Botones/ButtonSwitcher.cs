using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitcher : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;
    public GameObject AudioManager;
    Universal_AudioController AudioScript;
    void Start()
    {
        AudioManager = GameObject.Find("AudioController");
        if(AudioManager != null)
        {
            AudioScript = AudioManager.GetComponent<Universal_AudioController>();
            if(gameObject.name == "Music")
            {
                GetComponent<Button>().onClick.AddListener(AudioScript.MSwitcher);
            }
            else
            {
                GetComponent<Button>().onClick.AddListener(AudioScript.SSwitcher);
            }
            GetComponent<Button>().onClick.AddListener(switcher);
            switcher();
        }
    }
    public void switcher()
    {
        if(AudioScript != null)
        {
            if(gameObject.name == "Music")
            {
                if(AudioScript.stateM)
                {
                    GetComponent<Image>().sprite = On;
                }
                else
                {
                    GetComponent<Image>().sprite = Off;
                }
            }
            else
            {
                if(AudioScript.stateS)
                {
                    GetComponent<Image>().sprite = On;
                }
                else
                {
                    GetComponent<Image>().sprite = Off;
                }
            }
        }
    }
}
