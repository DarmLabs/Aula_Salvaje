using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReglasLengua : MonoBehaviour
{
    private int contadorHormigas;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
       Debug.Log("Colisiono con:   "+other.gameObject.name+"  "+other.gameObject.tag);
       if (other.gameObject.tag =="Alimentacion")
       {
           Destroy(other.gameObject);
           contadorHormigas+=1;
           Debug.Log("Hormigas comidas:   "+contadorHormigas);
       }
    }
}
