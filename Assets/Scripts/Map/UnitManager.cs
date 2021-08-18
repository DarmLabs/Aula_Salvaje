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
    void Start()//este script maneja a cada provincia individualmente
    {
        Name = GameObject.Find("Name");
        MainCamera = GameObject.Find("Main Camera");
        Default = gameObject.GetComponent<MeshRenderer>().material;
        LightMaterial = Resources.Load("Materials/LightMaterial", typeof(Material)) as Material;
        mapManager = MainCamera.GetComponent<MapManager>();
        uI_Manager = MainCamera.GetComponent<UI_Manager>();
        thisMeshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    void OnMouseEnter()//cuando el mouse esta sobre este objeto
    {
        if(mapManager.Zoom == false && uI_Manager.ScreenOnLeft == true)
        {
            OnAsigned();
        }
    }
    void OnMouseExit()//cuando el mouse sale de este objecto
    {
        if(mapManager.Zoom == false && uI_Manager.ScreenOnLeft == true)
        {
            OffAsigned();
        }
    }
    public void OnAsigned()//esta funcion cambia el color de la provincia para resaltarla y cambia propiedades para podes ser seleccionada
    {
        Name.gameObject.SetActive(true);
        Name.GetComponent<Text>().text = (gameObject.name.ToUpper());
        thisMeshRenderer.material = LightMaterial;
        gameObject.tag = "Provincia";
    }
    public void OffAsigned()//esta funcion devuelve el color y propiedades default
    {
        Name.gameObject.SetActive(false);
        thisMeshRenderer.material = Default;
        gameObject.tag = "OffProvincia";
    }
}
