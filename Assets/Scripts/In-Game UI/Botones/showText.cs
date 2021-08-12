using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class showText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject buttonsText;
    void Start()
    {
        buttonsText = GameObject.Find("buttonsText");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonsText.GetComponent<Text>().text = eventData.pointerEnter.gameObject.name;
        buttonsText.transform.position = eventData.pointerEnter.gameObject.transform.position;
        buttonsText.GetComponent<Animator>().Play("Desliz");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonsText.GetComponent<Animator>().Play("Desliz 0");
    }
}
