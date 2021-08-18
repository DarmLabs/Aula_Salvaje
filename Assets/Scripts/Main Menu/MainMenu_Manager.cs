using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour
{
    public GameObject AudioManager;
    public GameObject Panel;
    void Start()
    {
        AudioManager.transform.GetChild(1).transform.GetChild(0).GetComponent<AudioSource>().Play();//inicia la cancion del menu
    }
    public void PressPlay()//funcion al presionar play, carga la escena del mapa y caratulas
    {
        SceneManager.LoadSceneAsync("In-Game");
        ButtonSound();
    }
    public void PressCredits()//activa y desactiva los creditos
    {
        if(Panel.activeSelf == false)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
        ButtonSound();
    }
    public void ButtonSound()//funcion de sonido
    {
        AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
    }
}
