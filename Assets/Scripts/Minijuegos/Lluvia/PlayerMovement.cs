using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        float h = Input.GetAxis("Mouse X");
        this.gameObject.transform.Translate(h, 0, 0);
    }

}
