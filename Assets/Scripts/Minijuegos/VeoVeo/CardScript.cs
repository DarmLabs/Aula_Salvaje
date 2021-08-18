using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    VeoVeo_Manager veoVeo_Manager;
    void Start()
    {
        veoVeo_Manager = GameObject.Find("Canvas World Space").GetComponent<VeoVeo_Manager>();//busco el manager
        GetComponent<Button>().onClick.AddListener(veoVeo_Manager.selectCard);//agrego una funcion cuando se haga clic sobre una carta
        if(gameObject.name != "Correcto")//si el nombre del objeto no es correcto
        {
            GetComponent<Button>().onClick.AddListener(wrongCard);//activa la funcion
        }
    }
    void wrongCard()//esta funcion bloquea y apaga la carta
    {
        veoVeo_Manager.ButtonSound();
        GetComponent<Image>().color = Color.gray;
        GetComponent<Button>().interactable =false;
    }
}
