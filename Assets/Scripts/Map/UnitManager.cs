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
    UI_Manager uI_Manager;
    MapManager mapManager;
    MeshRenderer thisMeshRenderer;
    void Start()
    {
        Name = GameObject.Find("Name");
        MainCamera = GameObject.Find("Main Camera");
        Default = gameObject.GetComponent<MeshRenderer>().material;
        LightMaterial = Resources.Load("Materials/LightMaterial", typeof(Material)) as Material;
        mapManager = MainCamera.GetComponent<MapManager>();
        uI_Manager = MainCamera.GetComponent<UI_Manager>();
        thisMeshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if(mapManager.Zoom == false && uI_Manager.ScreenOnLeft == true)
        {
            OnAsigned();
        }
    }
    void OnMouseExit()
    {
        if(mapManager.Zoom == false && uI_Manager.ScreenOnLeft == true)
        {
            OffAsigned();
        }
    }
    public void OnAsigned()
    {
        Name.gameObject.SetActive(true);
        Name.GetComponent<Text>().text = (gameObject.name.ToUpper());
        thisMeshRenderer.material = LightMaterial;
        gameObject.tag = "Provincia";
    }
    public void OffAsigned()
    {
        Name.gameObject.SetActive(false);
        thisMeshRenderer.material = Default;
        gameObject.tag = "OffProvincia";
    }
}
