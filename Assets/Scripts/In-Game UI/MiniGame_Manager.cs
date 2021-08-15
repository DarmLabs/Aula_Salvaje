using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGame_Manager : MonoBehaviour
{
    public GameObject Panel;
    GameObject [] cards;
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(disableTuto(5));
    }
    public void PauseMenuOn()
    {
        Panel.SetActive(true);
        Panel.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseMenuOff()
    {
        Panel.SetActive(false);
        Panel.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
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
            }
        }
    }
    public void Exit()
    {
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
    }
    public void Lose_miniGame()
    {
        Panel.SetActive(true);
        Panel.transform.GetChild(3).gameObject.SetActive(true);
    }
}