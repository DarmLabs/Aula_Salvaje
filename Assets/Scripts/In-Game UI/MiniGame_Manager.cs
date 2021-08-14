using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame_Manager : MonoBehaviour
{
    public GameObject Panel;
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
}