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
    Vector3 positionRef = new Vector3(14.11f, -5.4f, 5.7f); //Posición de referencia en pantalla   
    public GameObject[] visualFeedbacks;
    public int countBasura = 0; //Contadores para items atrapados
    public int countBien = 0; //
    public int countMal = 0; //
    private Collider colision;
    Rigidbody2D rb;
    private float velocidad = 15f;
    public GameObject objManager;
    
    void Start()
    {        
        Cursor.lockState = CursorLockMode.Locked;
        
        rb = GetComponent<Rigidbody2D>();
        //aleatoriamente se instancia una carta de animal, para el cual deberemos seleccionar el alimento correcto
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
        //se mueve el personaje con las flechas de direccion, izquierda y derecha  
        float h =Input.GetAxis("Horizontal");     
        rb.velocity = new Vector2(h*velocidad,0f);
        if (countBien>=25)
        {
            objManager.GetComponent<MiniGame_Manager>().Win_miniGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (countMal >= 15 || countBasura >= 15)
        {
            objManager.GetComponent<MiniGame_Manager>().Lose_miniGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        
       //se comprueba que los items recogidos sean del tipo correcto, en caso de no serlo se le hace saber al jugador mediante feedback visual
       //
        
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
        if(Dieta == "Herbivoro")
        {
            if (other.gameObject.tag == "Herbivoro" )
            {            
                countBien += 1;
                Destroy(other.gameObject);
                GameObject Bien = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,transform.rotation);
                Destroy(Bien,0.4f);    
            }
            if (other.gameObject.tag == "Carnivoro" )
            {            
                countMal += 1;
                Destroy(other.gameObject);
                GameObject Mal = Instantiate(visualFeedbacks[1],other.gameObject.transform.position,transform.rotation);
                Destroy(Mal,0.4f);    
            }            
        }
        if(Dieta == "Carnivoro")
        {
            if (other.gameObject.tag == "Carnivoro" )
            {            
                countBien += 1;
                Destroy(other.gameObject);
                GameObject Bien = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,transform.rotation);
                Destroy(Bien,0.4f);    
            }
            if (other.gameObject.tag == "Herbivoro" )
            {            
                countMal += 1;
                Destroy(other.gameObject);
                GameObject Mal = Instantiate(visualFeedbacks[1],other.gameObject.transform.position,transform.rotation);
                Destroy(Mal,0.4f);    
            }            
        }
        if (other.gameObject.tag == "Basura")
        {            
            countBasura += 1;
            Destroy(other.gameObject);
            GameObject Mal = Instantiate(visualFeedbacks[1],other.gameObject.transform.position,transform.rotation);
            Destroy(Mal,0.4f);    
        }   

        
        
        
       
    }

}
