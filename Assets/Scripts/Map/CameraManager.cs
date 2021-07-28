using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GameObject Name;

    void Start()
    {
        Name = GameObject.Find("Name");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOnText();
        }
    }
    public void TurnOnText()
    {
        Name.GetComponent<Text>().enabled = true;
    }
    public void TurnOffText()
    {
        Name.GetComponent<Text>().enabled = false;
    }
}
