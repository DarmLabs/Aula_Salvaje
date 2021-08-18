using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public bool ScreenOnLeft = false;
    GameObject [] provincias;
    public GameObject Name;
    public GameObject Animales;
    public GameObject selectedProvincia;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject CuadernoWorldSpace;
    public GameObject CuadernoOverlay;
    public GameObject textureButtons;
    public GameObject refRelieves;
    public GameObject refBiomas;
    public GameObject refRegiones;
    public GameObject exitMapButton;
    public GameObject Inicios;
    public GameObject Bloqueador_Inicio;
    public GameObject AudioManager;
    string selectedButton;
    string previousButton;
    GameObject clickedButton;
    public Texture relieveTexture;
    public Texture biomasTexture;
    public Texture provinciasTexture;
    public Texture regionesTexture;
    public int currentTexture;

    void Start()
    {
        Time.timeScale = 1;//el tiempo se setea a 1 ya que si viene de un minijuego el tiempo es 0
        AudioManager = GameObject.Find("AudioController");//se busca el controlador de audio
        if(AudioManager != null)//detiene otras canciones
        {
            AudioManager.transform.GetChild(1).transform.GetChild(1).GetComponent<AudioSource>().Stop();
            AudioManager.transform.GetChild(1).transform.GetChild(2).GetComponent<AudioSource>().Stop();
        }
        
        Name.gameObject.SetActive(false);
        provincias = GameObject.FindGameObjectsWithTag("OffProvincia");
    }
    void Update()
    {
        Name.transform.position = Input.mousePosition;//lleva el texto que muestra el nombre de la provincia a la posicion del mouse
    }
    public void TurnOnText()
    {
        Name.GetComponent<Text>().enabled = true; //activa el texto del nombre de las provincias 
    }
    public void TurnOffText()
    {
        Name.GetComponent<Text>().enabled = false;// aqui lo desactiva
    }
    public void SelectionOn() //al selecciona una provincia se toma el nombre de la provincia y se muestran sus respectivos animales
    {
        selectedProvincia = Animales.transform.Find(GetComponent<MapManager>().currentProvincia).gameObject;
        selectedProvincia.SetActive(true);
    }
    public void SelectionOff() //aqui se desactivan
    {
        selectedProvincia.SetActive(false);
    }
    public void SlideToRight() //esta funcion se ejecuta al deslizar la camara hacia la derecha y entrar en la pantalla "Juega"
    {
        GetComponent<Animator>().Play("Deslizar Derecha");
        LeftButton.GetComponent<Button>().enabled = false;
        GetComponent<MapManager>().enabled = false;
        ScreenOnLeft = false;
        ButtonSound();
    }
    public void SlideToLeft() //esta funcion se ejecuta al deslizar la camara hacia la izquierda y entrar en la pantalla "Aprende"
    {
        GetComponent<Animator>().Play("Deslizar Izquierda");
        RightButton.GetComponent<Button>().enabled = false;
        ButtonSound();
    }
    public void OnRight() //Esta funcion se reproduce al terminar la transicion de izquierda a derecha
    {
        RightButton.GetComponent<Button>().enabled = true;
    }
    public void OnLeft()//Esta funcion se reproduce al terminar la transicion de derecha a izquierda
    {
        Bloqueador_Inicio.SetActive(false);
        ScreenOnLeft = true;
        LeftButton.GetComponent<Button>().enabled = true;
        GetComponent<MapManager>().enabled = true;
    }
    public void InfoPanelOn()//activa el panel de informacion de animales (detalle)
    {
        CuadernoOverlay.SetActive(true);
        CuadernoWorldSpace.SetActive(false);
        textureButtons.SetActive(false);
    }
    public void InfoPanelOff()//desactiva el panel de informacion de animales (detalle)
    {
        CuadernoOverlay.SetActive(false);
        CuadernoWorldSpace.SetActive(true);
        textureButtons.SetActive(true);
    }
    public void PressFlap()//al presionar una solapa se activa la caratula propia de la solapa y esta despararece
    {
        if(previousButton != null)
        {
            Inicios.transform.Find(previousButton).gameObject.SetActive(false);
            clickedButton.SetActive(true);
        }
        selectedButton = EventSystem.current.currentSelectedGameObject.name;
        clickedButton = EventSystem.current.currentSelectedGameObject.gameObject;
        clickedButton.SetActive(false);
        Inicios.transform.Find(selectedButton).gameObject.SetActive(true);
        previousButton = selectedButton;
        FlapSound();
    }
    public void ChangeScene()//se utiliza para cambiar a la escena del minijuego de la caratula activada
    {
        SceneManager.LoadSceneAsync(selectedButton);   
    }
    public void exitMapButtonOn()//activa el boton que hace zoom out al mapa 
    {
        exitMapButton.SetActive(true);
    }
    public void exitMapButtonOff()//desactiva el boton que hace zoom out al mapa 
    {
        exitMapButton.SetActive(false);
        ButtonSound();
    }
    public void switchTexture()//esta funcion cambia la textura del mapa segun los botones geograficos
    {
        refRelieves.SetActive(false);
        refBiomas.SetActive(false);
        refRegiones.SetActive(false);
        if(EventSystem.current.currentSelectedGameObject.name == "Relieves")
        {
            refRelieves.SetActive(true);
            foreach (var provincia in provincias)
            {
                provincia.GetComponent<MeshRenderer>().material.mainTexture = relieveTexture;
            }
        }
        if(EventSystem.current.currentSelectedGameObject.name == "Biomas")
        {
            refBiomas.SetActive(true);
            foreach (var provincia in provincias)
            {
                provincia.GetComponent<MeshRenderer>().material.mainTexture = biomasTexture;
            }
        }
        if(EventSystem.current.currentSelectedGameObject.name == "Provincias")
        {
            foreach (var provincia in provincias)
            {
                provincia.GetComponent<MeshRenderer>().material.mainTexture = provinciasTexture;
            }
        }
        if(EventSystem.current.currentSelectedGameObject.name == "Regiones")
        {
            refRegiones.SetActive(true);
            foreach (var provincia in provincias)
            {
                provincia.GetComponent<MeshRenderer>().material.mainTexture = regionesTexture;
            }
        }
        ButtonSound();
    }
    public void ButtonSound()//funcion del sonido de boton
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
        }      
    }
    public void FlapSound()//funcion del sonido de la solapa
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(0).transform.GetChild(1).GetComponent<AudioSource>().Play();
        }   
    }
}
