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
    public void ClearTexts()
    {
        TituloPanel.GetComponent<Text>().text = "";
        InfoPanel.GetComponent<Text>().text = "";
        StartCoroutine(addText(1));
    }
    IEnumerator addText(int secs)
    {
        yield return new WaitForSeconds(secs);
        InfoPanel.GetComponent<Text>().text = "Has clic sobre un animal para saber más sobre él!";
    }
}
