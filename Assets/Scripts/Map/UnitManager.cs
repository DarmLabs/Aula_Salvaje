using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{
    Material Default;
    public Material LightMaterial;
    GameObject Name;
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
        if(MainCamera.GetComponent<MapManager>().Zoom == false)
        {
            Name.GetComponent<Text>().text = (gameObject.name);
            gameObject.GetComponent<MeshRenderer>().material = LightMaterial;
            gameObject.tag = "Provincia";
        }
    }
    void OnMouseExit()
    {
        if(MainCamera.GetComponent<MapManager>().Zoom == false)
        {
            gameObject.GetComponent<MeshRenderer>().material = Default;
            Name.GetComponent<Text>().text = "";
            gameObject.tag = "Untagged";
        }
    }
}
