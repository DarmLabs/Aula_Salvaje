using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    VeoVeo_Manager veoVeo_Manager;
    void Start()
    {
        veoVeo_Manager = GameObject.Find("Canvas World Space").GetComponent<VeoVeo_Manager>();
        GetComponent<Button>().onClick.AddListener(veoVeo_Manager.selectCard);
        if(gameObject.name != "Correcto")
        {
            GetComponent<Button>().onClick.AddListener(wrongCard);
        }
        
    }
    void wrongCard()
    {
        GetComponent<Image>().color = Color.gray;
        GetComponent<Button>().interactable =false;
    }
}
