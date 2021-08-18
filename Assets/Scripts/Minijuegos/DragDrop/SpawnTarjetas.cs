using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarjetas : MonoBehaviour
{
    public GameObject[] Tarjetas;
    public Transform[] spawnPoints;
    private int indexTarjetas = 19;
    private int indexRandom;
    private int indexAnterior;


    
    void Start () 
    {       
           //se crea una de las cartas cargadas  a las posiciones establecidas con anterioridad, de manera aleatoria
           for (int i = 0; i < 6; i++)
           {
                indexRandom = Random.Range(0,indexTarjetas);        
                Instantiate(Tarjetas[indexRandom],spawnPoints[i].position,transform.rotation);               
           }     

    }

   

   
   
}
