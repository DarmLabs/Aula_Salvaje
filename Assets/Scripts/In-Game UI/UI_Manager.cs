using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject Name;
    public GameObject Animales;
    public GameObject selectedProvincia;

    void Start()
    {
        
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
}
