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
        DontDestroyOnLoad(gameObject);//permite que el script siga activo en todas las escenas
    }
    void Start()//busco los contenedores de sonidos y musica
    {
        MusicContainer = transform.Find("MusicTracks").gameObject;
        SFXContainer = transform.Find("SFX").gameObject;
    }
    public void SSwitcher()//esta funcion genera una animacion de encendido y apagado en los botones de sonido
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
    public void MSwitcher()//esta funcion genera una animacion de encendido y apagado en los botones de musica
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
