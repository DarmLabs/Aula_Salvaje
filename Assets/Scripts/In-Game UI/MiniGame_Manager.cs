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
        AudioManager = GameObject.Find("AudioController"); //Al inicio busco el controlador de audio
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(1).transform.GetChild(0).GetComponent<AudioSource>().Stop(); //Detengo la musica del menu
            if(SceneManager.GetActiveScene().name == "Memoria" || SceneManager.GetActiveScene().name == "DragDrop" || SceneManager.GetActiveScene().name == "VeoVeo") //Inicio otra cancion segun la escena
            {
                AudioManager.transform.GetChild(1).transform.GetChild(1).GetComponent<AudioSource>().Play();
            }
            else
            {
                AudioManager.transform.GetChild(1).transform.GetChild(2).GetComponent<AudioSource>().Play();
            }
        }
        Time.timeScale = 0; //Detengo el tiempo para mostrar el tutorial
        StartCoroutine(disableTuto(5));
    }
    public void PauseMenuOn()//Al apretar el boton de pausa se reproduce el sonido respectivo de los botones y se activa el popup
    {
        ButtonSound();
        Panel.SetActive(true);
        Panel.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseMenuOff()//Al salir del popup el menu de pausa se desactiva
    {
        ButtonSound();
        Panel.SetActive(false);
        Panel.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()//En esta funcion se reinicia el minijuego
    {
        ButtonSound();
        if(SceneManager.GetActiveScene().name != "VeoVeo") //Reinicia la escena
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            if(Panel.transform.GetChild(2).gameObject.activeSelf == true)//Condicion especial cuando el reinicio ocurre desde la pantalla de victoria del veo veo (Nueva pista y cartas)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else//Condicion especial para el veo veo, se reactivan las cartas (mismas cartas)
            {
                GetComponent<VeoVeo_Manager>().RestartVeoWin();
                cards = GameObject.FindGameObjectsWithTag("card");
                foreach (var card in cards)//devuelvo el color normal a la carta y la reactivo
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
    public void Exit()//sale del minijuego y vuelve a la pantalla del mapa
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(1).transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
        ButtonSound();
        SceneManager.LoadScene(1);
    }
    IEnumerator disableTuto(int secs)//desactivo el tutorial
    {
        yield return new WaitForSecondsRealtime(secs);
        Panel.transform.GetChild(1).gameObject.SetActive(false);
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Win_miniGame()//funcion de activacion del popup de victoria
    {
        Panel.SetActive(true);
        Panel.transform.GetChild(2).gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Lose_miniGame()//funcion de activacion del popup de derrota
    {
        Panel.SetActive(true);
        Panel.transform.GetChild(3).gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ButtonSound()//funcion para reproducir el sonido de los botones
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
        }      
    }
}