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
    public GameObject MainCamera;
    string currentProvincia;
    bool Using = false;
    void Start()
    {
        Name = GameObject.Find("Name");
        MainCamera = GameObject.Find("Main Camera");
        Default = gameObject.GetComponent<MeshRenderer>().material;
        LightMaterial = Resources.Load("Materials/LightMaterial", typeof(Material)) as Material;
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        Name.transform.position = mousePosition;
        if(Input.GetMouseButton(0))
        {
            if(!Using)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnMouseEnter()
    {
        if(!Using)
        {
            Name.GetComponent<Text>().text = (gameObject.name);
            gameObject.GetComponent<MeshRenderer>().material = LightMaterial;
        }
    }
    void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = Default;
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButton(0))
        {
            MainCamera.GetComponent<Animator>().Play(gameObject.name);
            Using = true;
            MainCamera.GetComponent<CameraManager>().TurnOffText();
            gameObject.GetComponent<MeshRenderer>().material = Default;
        }
    }
    void Controls()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
        }
    }
    void OffProvincias()
    {
        if(currentProvincia != gameObject.name)
        {
            gameObject.SetActive(false);
        }
    }
}
