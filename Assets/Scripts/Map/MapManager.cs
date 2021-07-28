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
            OffProvincias();
        }
        Controls();
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MainCamera.GetComponent<Animator>().Play(gameObject.name + " 0");
            Using = false;
            OnProvincias();
        }
    }   
    void OnProvincias()
    {
        if(!Using)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            if(gameObject.GetComponent<MeshCollider>() != null)
            {
                gameObject.GetComponent<MeshCollider>().enabled = true;
            }
            if(gameObject.GetComponent<BoxCollider>() != null)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
    void OffProvincias()
    {
        if(!Using)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if(gameObject.GetComponent<MeshCollider>() != null)
            {
                gameObject.GetComponent<MeshCollider>().enabled = false;
            }
            if(gameObject.GetComponent<BoxCollider>() != null)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
