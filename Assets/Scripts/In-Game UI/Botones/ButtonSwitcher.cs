using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSwitcher : MonoBehaviour
{
    //Este scropt se encuentra en todos los botones Music y Sound de todas las escenas y son los encargados de prender y apagar el audio
    public Sprite On;
    public Sprite Off;
    public GameObject AudioManager;
    Universal_AudioController AudioScript;
    void Start()
    {
        //Tomo el controlador para el audio
        AudioManager = GameObject.Find("AudioController");
        if(AudioManager != null)
        {
            AudioScript = AudioManager.GetComponent<Universal_AudioController>();
            if(gameObject.name == "Music") //Aqui agrego las funciones que los botones con el nombre "Music" deben reproducir (MSwitcher, desde el script de audio y Resume Music)
            {
                GetComponent<Button>().onClick.AddListener(AudioScript.MSwitcher);
                GetComponent<Button>().onClick.AddListener(ResumeMusic);
                AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play(); //Reproduzco el sonido para los botones
            }
            else //else funciona para los botones que controlan el sonido cambiando la variable SSwitcher del script de audio
            {
                GetComponent<Button>().onClick.AddListener(AudioScript.SSwitcher);
                AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play(); //Reproduzco el sonido para los botones
            }
            GetComponent<Button>().onClick.AddListener(switcher); //Agrego la funcion de switcher cada vez que el boton es presionado
            switcher(); 
        }
    }
    public void switcher()
    {
        if(AudioScript != null)
        {
            if(gameObject.name == "Music") //Cambio de sprite de encendido y apagado
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
    public void ResumeMusic() //La funcion resume music reactiva la musica luego de encender la musica a traves de un boton dependiendo de la escena
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
