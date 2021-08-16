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
        Time.timeScale = 1;
        AudioManager = GameObject.Find("AudioController");
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(1).transform.GetChild(1).GetComponent<AudioSource>().Stop();
            AudioManager.transform.GetChild(1).transform.GetChild(2).GetComponent<AudioSource>().Stop();
        }
        
        Name.gameObject.SetActive(false);
        provincias = GameObject.FindGameObjectsWithTag("OffProvincia");
    }
    void Update()
    {
        Name.transform.position = Input.mousePosition;
    }
    public void TurnOnText()
    {
        Name.GetComponent<Text>().enabled = true;
    }
    public void TurnOffText()
    {
        Name.GetComponent<Text>().enabled = false;
    }
    public void SelectionOn()
    {
        selectedProvincia = Animales.transform.Find(GetComponent<MapManager>().currentProvincia).gameObject;
        selectedProvincia.SetActive(true);
    }
    public void SelectionOff()
    {
        selectedProvincia.SetActive(false);
    }
    public void SlideToRight()
    {
        GetComponent<Animator>().Play("Deslizar Derecha");
        LeftButton.GetComponent<Button>().enabled = false;
        GetComponent<MapManager>().enabled = false;
        ScreenOnLeft = false;
        ButtonSound();
    }
    public void SlideToLeft()
    {
        GetComponent<Animator>().Play("Deslizar Izquierda");
        RightButton.GetComponent<Button>().enabled = false;
        ButtonSound();
    }
    public void OnRight()
    {
        RightButton.GetComponent<Button>().enabled = true;
    }
    public void OnLeft()
    {
        Bloqueador_Inicio.SetActive(false);
        ScreenOnLeft = true;
        LeftButton.GetComponent<Button>().enabled = true;
        GetComponent<MapManager>().enabled = true;
    }
    public void InfoPanelOn()
    {
        CuadernoOverlay.SetActive(true);
        CuadernoWorldSpace.SetActive(false);
        textureButtons.SetActive(false);
    }
    public void InfoPanelOff()
    {
        CuadernoOverlay.SetActive(false);
        CuadernoWorldSpace.SetActive(true);
        textureButtons.SetActive(true);
    }
    public void PressFlap()
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
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(selectedButton);   
    }
    public void exitMapButtonOn()
    {
        exitMapButton.SetActive(true);
    }
    public void exitMapButtonOff()
    {
        exitMapButton.SetActive(false);
        ButtonSound();
    }
    public void switchTexture()
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
    public void ButtonSound()
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
        }      
    }
    public void FlapSound()
    {
        if(AudioManager != null)
        {
            AudioManager.transform.GetChild(0).transform.GetChild(1).GetComponent<AudioSource>().Play();
        }   
    }
}
