using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TextReader : MonoBehaviour
{
    string animName;
    public GameObject InfoPanel;
    public GameObject TituloPanel;
    public GameObject AudioManager;
    void Start()
    {
        AudioManager = GameObject.Find("AudioController");//busco el controlador de audio
    }
    public void PrintFiles()//en esta funcion se imprimen los .txt guardados en la carpeta Resoruces/InfoAnimales
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(0).transform.GetChild(2).GetComponent<AudioSource>().Play();
        }   
        animName = EventSystem.current.currentSelectedGameObject.name;//nombre del boton presionado
        TextAsset file = Resources.Load<TextAsset>("InfoAnimales/"+animName);//carga el .txt segun el nombre del animal seleccionado
        if(file != null)//en esta condicion se modifican el formato del texto (mayusculas y posicion)
        {
            InfoPanel.GetComponent<Text>().text = file.text.ToUpper();
            InfoPanel.GetComponent<Text>().alignment = TextAnchor.UpperLeft;
        }
        else//si un animal no tiene informacion saldra esto
        {
            InfoPanel.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
            InfoPanel.GetComponent<Text>().text = "Lo sentimos, no hay informacion :(".ToUpper();
        }
        TituloPanel.GetComponent<Text>().text = animName.ToUpper();
        animName = null;
    }
    public void ClearTexts()//esta funcion se reproduce al hacer zoom en una provincia 
    {
        TituloPanel.GetComponent<Text>().text = "";
        InfoPanel.GetComponent<Text>().text = "";
        StartCoroutine(addText(1));
    }
    IEnumerator addText(int secs)//luego de hacer zoom en la provincia esta funcion dara un mensaje
    {
        yield return new WaitForSeconds(secs);
        InfoPanel.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
        InfoPanel.GetComponent<Text>().text = "Has clic sobre un animal para saber más sobre él!".ToUpper();
    }
}
