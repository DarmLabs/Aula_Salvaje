using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                GetComponent<Button>().onClick.AddListener(ResumeMusic);
                AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<Button>().onClick.AddListener(AudioScript.SSwitcher);
                AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
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
    public void ResumeMusic()
    {
        if(SceneManager.GetActiveScene().name == "In-Game")
        {
            AudioManager.transform.GetChild(1).transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
        if(SceneManager.GetActiveScene().name == "Memoria" || SceneManager.GetActiveScene().name == "DragDrop" || SceneManager.GetActiveScene().name == "VeoVeo")
        {
            AudioManager.transform.GetChild(1).transform.GetChild(1).GetComponent<AudioSource>().Play();
        }
        if(SceneManager.GetActiveScene().name == "Carrera" || SceneManager.GetActiveScene().name == "Labernito" || SceneManager.GetActiveScene().name == "LluviadeComida")
        {
            AudioManager.transform.GetChild(1).transform.GetChild(2).GetComponent<AudioSource>().Play();
        }
    }
}
