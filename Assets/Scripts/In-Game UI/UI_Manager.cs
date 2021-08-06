using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Manager : MonoBehaviour
{
    public GameObject Name;
    public GameObject Animales;
    public GameObject selectedProvincia;
    public bool ScreenOnLeft = false;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject CuadernoWorldSpace;
    public GameObject CuadernoOverlay;
    string selectedButton;
    string previousButton;
    public GameObject Inicios;
    GameObject clickedButton;

    void Start()
    {
        Name.gameObject.SetActive(false);
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
    }
    public void SlideToLeft()
    {
        GetComponent<Animator>().Play("Deslizar Izquierda");
        RightButton.GetComponent<Button>().enabled = false;
    }
    public void OnRight()
    {
        RightButton.GetComponent<Button>().enabled = true;
    }
    public void OnLeft()
    {
        ScreenOnLeft = true;
        LeftButton.GetComponent<Button>().enabled = true;
        GetComponent<MapManager>().enabled = true;
    }
    public void InfoPanelOn()
    {
        CuadernoOverlay.SetActive(true);
        CuadernoWorldSpace.SetActive(false);
    }
    public void InfoPanelOff()
    {
        CuadernoOverlay.SetActive(false);
        CuadernoWorldSpace.SetActive(true);
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
    }
}
