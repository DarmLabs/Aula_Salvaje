using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Universal_AudioController : MonoBehaviour
{
    GameObject MusicContainer;
    GameObject SFXContainer;
    public bool stateM = true;
    public bool stateS = true;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        MusicContainer = transform.Find("MusicTracks").gameObject;
        SFXContainer = transform.Find("SFX").gameObject;
    }
    public void SSwitcher()
    {
        if(stateS)
        {
            stateS = false;
            SFXContainer.SetActive(false);
        }
        else
        {
            stateS = true;
            SFXContainer.SetActive(true);
        }
    }
    public void MSwitcher()
    {
        if(stateM)
        {
            stateM = false;
            MusicContainer.SetActive(false);
        }
        else
        {
            stateM = true;
            MusicContainer.SetActive(true);
        }
    }
}
