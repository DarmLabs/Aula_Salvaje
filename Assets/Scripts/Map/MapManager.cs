using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    Material Default;
    public Material LightMaterial;
    GameObject Name;
    Vector3 mousePosition;
    void Start()
    {
        Name = GameObject.Find("Name");
        Default = gameObject.GetComponent<MeshRenderer>().material;
        LightMaterial = Resources.Load("Materials/LightMaterial", typeof(Material)) as Material;
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        Name.transform.position = mousePosition;
    }

    void OnMouseEnter()
    {
        Name.GetComponent<Text>().text = (gameObject.name);
        gameObject.GetComponent<MeshRenderer>().material = LightMaterial;
    }
    void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = Default;
    }
}
