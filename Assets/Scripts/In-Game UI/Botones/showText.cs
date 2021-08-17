using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class showText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Este script muestra maneja un texto que muestra que es cada boton de cambio de textura
    GameObject buttonsText;
    void Start()
    {
        buttonsText = GameObject.Find("buttonsText"); //Busca el texto
    }
    public void OnPointerEnter(PointerEventData eventData) //Cuando el mouse entra en el boton muestra el texto
    {
        buttonsText.GetComponent<Text>().text = eventData.pointerEnter.gameObject.name.ToUpper();
        buttonsText.transform.position = eventData.pointerEnter.gameObject.transform.position;
        buttonsText.GetComponent<Animator>().Play("Desliz");
    }
    public void OnPointerExit(PointerEventData eventData) //Cuando sale del boton se oculta el texto
    {
        buttonsText.GetComponent<Animator>().Play("Desliz 0");
    }
}
