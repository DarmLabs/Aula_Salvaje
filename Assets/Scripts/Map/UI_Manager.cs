using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject Name;
    public GameObject UI;

    void Start()
    {
        
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
        UI.gameObject.SetActive(true);
    }
    public void TurnOffText()
    {
        Name.GetComponent<Text>().enabled = false;
    }
}
