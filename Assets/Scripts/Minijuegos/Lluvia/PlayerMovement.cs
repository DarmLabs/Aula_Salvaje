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
    Vector3 positionRef = new Vector3(7.4f, -3.28f, 0f); //Posición de referencia en pantalla   
    public GameObject visualFeedback;
    void Start()
    {        
        Dieta = Dietas[Random.Range(0,2)];
        switch (Dieta)
        {
        case "Carnivoro":
            Instantiate(AnimalesCarnivoros[Random.Range(0,2)],positionRef,transform.rotation);
            break;
        case "Herbivoro":
            Instantiate(AnimalesHerbivoros[Random.Range(0,2)],positionRef,transform.rotation);
            break;
        case "Omnivoro":
            Instantiate(AnimalesOmnivoros[Random.Range(0,2)],positionRef,transform.rotation);
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
            Destroy(other.gameObject);
            GameObject Bien = Instantiate(visualFeedback,other.gameObject.transform.position,transform.rotation);
            Destroy(Bien,0.4f);    
        }
       
    }

}
