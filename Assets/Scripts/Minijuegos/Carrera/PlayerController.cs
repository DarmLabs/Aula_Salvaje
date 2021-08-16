using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float velocidadV = 10f;
    private float velocidadH = 3f;

    
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        Movimiento();       
    }
    void Movimiento()
    {
       
        float h = Input.GetAxis("Mouse Y");        
        rb.velocity = new Vector2(velocidadH,h*velocidadV);
        transform.Rotate(0,0,-velocidadH);     
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        switch (other.gameObject.name)
        {
            case "Cactus":
            velocidadH = velocidadH - 0.3f;
            break;
            case "Charco":
            velocidadH = velocidadH - 0.1f;
            break;
            case "Piedras":
            velocidadH = velocidadH - 0.5f;
            break;
            case "Pozo":
            velocidadH = velocidadH - 0.4f;
            break;
        }
    }


}
