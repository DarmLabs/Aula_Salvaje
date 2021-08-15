using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string[] Dietas; // Categorías de animales según su alimentación
    public string Dieta;
    public GameObject[] AnimalesCarnivoros;// Sprites de animales según su alimentación
    public GameObject[] AnimalesHerbivoros;//   
    public GameObject[] AnimalesOmnivoros;//
    Vector3 positionRef = new Vector3(13f, -6.4f, 5.7f); //Posición de referencia en pantalla   
    public GameObject[] visualFeedbacks;
    public int countBasura = 0; //Contadores para items atrapados
    public int countBien = 0; //
    public int countMal = 0; //
    private Collider colision;
    
    void Start()
    {        
        Dieta = Dietas[Random.Range(0,3)];
        switch (Dieta)
        {
        case "Carnivoro":
            GameObject Carta0 = Instantiate(AnimalesCarnivoros[Random.Range(0,3)],positionRef,transform.rotation);
            break;
        case "Herbivoro":
            GameObject Carta1 = Instantiate(AnimalesHerbivoros[Random.Range(0,3)],positionRef,transform.rotation);      
            break;
        case "Omnivoro":
            GameObject Carta2 = Instantiate(AnimalesOmnivoros[Random.Range(0,3)],positionRef,transform.rotation); 
            break;        
        }
    }
   
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        float h = Input.GetAxis("Mouse X");
        this.gameObject.transform.Translate(h, 0f, 0f);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == Dieta)
        {            
            countBien += 1;
            Destroy(other.gameObject);
            GameObject Bien = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,transform.rotation);
            Destroy(Bien,0.4f);    
        }
        if(Dieta == "Omnivoro")
        {
            if (other.gameObject.tag == "Carnivoro" || other.gameObject.tag == "Herbivoro" )
            {            
                countBien += 1;
                Destroy(other.gameObject);
                GameObject Bien = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,transform.rotation);
                Destroy(Bien,0.4f);    
            }
        }
        if (other.gameObject.tag == "Basura")
        {            
            countBasura += 1;
            Destroy(other.gameObject);
            GameObject Mal = Instantiate(visualFeedbacks[1],other.gameObject.transform.position,transform.rotation);
            Destroy(Mal,0.4f);    
        }        
        switch (Dieta)
        {
        case "Carnivoro":
            if (other.gameObject.tag == "Herbivoro")
            Destroy(other.gameObject);
            GameObject MalH = Instantiate(visualFeedbacks[2],other.gameObject.transform.position,transform.rotation);
            Destroy(MalH,0.4f);    
            break;
        case "Herbivoro":
            if (other.gameObject.tag == "Carnivoro")
            Destroy(other.gameObject);
            GameObject MalC = Instantiate(visualFeedbacks[2],other.gameObject.transform.position,transform.rotation);
            Destroy(MalC,0.4f);       
            break;               
        }
        
       
    }

}
