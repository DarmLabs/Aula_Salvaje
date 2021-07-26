using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnOff : MonoBehaviour
{
    public GameObject Name;

    void Start()
    {
        Name = GameObject.Find("Name");
    }

    public void TurnOnText()
    {
        Name.GetComponent<Text>().enabled = true;
    }
}
