using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame_Manager : MonoBehaviour
{
    public GameObject Panel;
    public void PauseMenuOn()
    {
        Panel.SetActive(true);
        Panel.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void PauseMenuOff()
    {
        Panel.SetActive(false);
        Panel.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
