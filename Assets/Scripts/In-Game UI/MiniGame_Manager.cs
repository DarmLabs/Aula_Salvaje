using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGame_Manager : MonoBehaviour
{
    public GameObject Panel;
    public GameObject AudioManager;
    GameObject [] cards;
    void Start()
    {
        AudioManager = GameObject.Find("AudioController");
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(1).transform.GetChild(0).GetComponent<AudioSource>().Stop();
            if(SceneManager.GetActiveScene().name == "Memoria" || SceneManager.GetActiveScene().name == "DragDrop" || SceneManager.GetActiveScene().name == "VeoVeo")
            {
                AudioManager.transform.GetChild(1).transform.GetChild(1).GetComponent<AudioSource>().Play();
            }
            else
            {
                AudioManager.transform.GetChild(1).transform.GetChild(2).GetComponent<AudioSource>().Play();
            }
        }
        Time.timeScale = 0;
        StartCoroutine(disableTuto(5));
    }
    public void PauseMenuOn()
    {
        ButtonSound();
        Panel.SetActive(true);
        Panel.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseMenuOff()
    {
        ButtonSound();
        Panel.SetActive(false);
        Panel.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        ButtonSound();
        if(SceneManager.GetActiveScene().name != "VeoVeo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            if(Panel.transform.GetChild(2).gameObject.activeSelf == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                GetComponent<VeoVeo_Manager>().RestartVeoWin();
                cards = GameObject.FindGameObjectsWithTag("card");
                foreach (var card in cards)
                {
                    card.GetComponent<Image>().color = new Color(255,255,255,255);
                    card.GetComponent<Button>().interactable = true;
                }
                Panel.SetActive(false);
                Panel.transform.GetChild(3).gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void Exit()
    {
        AudioManager.transform.GetChild(1).transform.GetChild(0).GetComponent<AudioSource>().Play();
        ButtonSound();
        SceneManager.LoadScene(1);
    }
    IEnumerator disableTuto(int secs)
    {
        yield return new WaitForSecondsRealtime(secs);
        Panel.transform.GetChild(1).gameObject.SetActive(false);
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Win_miniGame()
    {
        Panel.SetActive(true);
        Panel.transform.GetChild(2).gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Lose_miniGame()
    {
        Panel.SetActive(true);
        Panel.transform.GetChild(3).gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ButtonSound()
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
        }      
    }
}