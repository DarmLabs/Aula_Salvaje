using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
   
    void Start()
    {
        //identifica la posición del personaje
        playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    void Update()
    {
        //la camara adquiere la posicion del personaje en el eje x
        Vector3 temp =transform.position;
        temp.x=playerTransform.position.x;
        transform.position=temp;
        
    }
}
