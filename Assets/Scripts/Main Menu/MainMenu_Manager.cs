using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour
{
    public void PressPlay()
    {
        SceneManager.LoadSceneAsync("In-Game");
    }
}
