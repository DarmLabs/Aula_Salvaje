using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    Material Default;
    Material LightMaterial;
    public GameObject Name;
    GameObject MainCamera;
    void Start()
    {
        Name = GameObject.Find("Name");
        MainCamera = GameObject.Find("Main Camera");
        Default = gameObject.GetComponent<MeshRenderer>().material;
        LightMaterial = Resources.Load("Materials/LightMaterial", typeof(Material)) as Material;
    }

    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if(MainCamera.GetComponent<MapManager>().Zoom == false && MainCamera.GetComponent<UI_Manager>().ScreenOnLeft == true)
        {
            OnAsigned();
        }
    }
    void OnMouseExit()
    {
        if(MainCamera.GetComponent<MapManager>().Zoom == false && MainCamera.GetComponent<UI_Manager>().ScreenOnLeft == true)
        {
            OffAsigned();
        }
    }
    public void OnAsigned()
    {
        Name.gameObject.SetActive(true);
        Name.GetComponent<Text>().text = (gameObject.name);
        gameObject.GetComponent<MeshRenderer>().material = LightMaterial;
        gameObject.tag = "Provincia";
    }
    public void OffAsigned()
    {
        Name.gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().material = Default;
        gameObject.tag = "Untagged";
    }
}
