using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VeoVeo_Manager : MonoBehaviour
{
    int numeroPlantillas;
    GameObject actualPlantillaPrefab;
    public GameObject actualPlantilla;
    public GameObject AudioManager;
    void Start()
    {
        AudioManager = GameObject.Find("AudioController");//toma el controlador de audio
        StartCoroutine(spawnAfterTime(5));
    }
    public int intentos = 3;
    public Text textIntentos;
    public void SpawnRandomPlantilla()//hay 5 plantillas (pista y cartas) esta funcion toma una de esas 5 de la carepta y las pone en la escena
    {
        numeroPlantillas = Random.Range(1,6);
        actualPlantillaPrefab = Resources.Load("Minijuegos/VeoVeo/Plantilla_"+numeroPlantillas.ToString()) as GameObject;
        actualPlantilla = Instantiate (actualPlantillaPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
        actualPlantilla.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,0,0);
        textIntentos.gameObject.SetActive(true);
    }
    public void selectCard()
    {
        ButtonSound();
        if(EventSystem.current.currentSelectedGameObject.name == "Correcto")//si el nombre de la carta es correcto gana el minijuego
        {
            GetComponent<MiniGame_Manager>().Win_miniGame();
        }
        else//sino resta un intento
        {
            intentos = intentos - 1;
            textIntentos.text = ("INTENTOS: "+intentos.ToString());
            if(intentos == 0)//si los intentos llehan a 0 pierde
            {
                GetComponent<MiniGame_Manager>().Lose_miniGame();
            }
        }
    }
    public void RestartVeoWin()//se reinicia la misma plantilla del veo veo
    {
        intentos = 3;
        textIntentos.text = ("INTENTOS: "+intentos.ToString());
    }
    IEnumerator spawnAfterTime(int secs)//esta funcion hace aparecer la plantilla luego del tutorial
    {
        yield return new WaitForSecondsRealtime(secs);
        SpawnRandomPlantilla();
    }
    public void ButtonSound()//funcion del sonido de boton
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
        }      
    }
}
