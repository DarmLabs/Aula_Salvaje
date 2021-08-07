using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TextReader : MonoBehaviour
{
    string animName;
    public GameObject InfoPanel;
    public GameObject TituloPanel;
    public void PrintFiles()
    {
        animName = EventSystem.current.currentSelectedGameObject.name;
        TextAsset file = Resources.Load<TextAsset>("InfoAnimals/"+animName);
        if(file != null)
        {
            InfoPanel.GetComponent<Text>().text = file.text;
            InfoPanel.GetComponent<Text>().alignment = TextAnchor.UpperLeft;
        }
        else
        {
            InfoPanel.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
            InfoPanel.GetComponent<Text>().text = "Lo sentimos, no hay informacion :c";
        }
        TituloPanel.GetComponent<Text>().text = animName;
        animName = null;
    }
}
