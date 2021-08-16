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
           for (int i = 0; i < 5; i++)
           {
                indexRandom = Random.Range(0,indexTarjetas);        
                Instantiate(Tarjetas[indexRandom],spawnPoints[i].position,transform.rotation);               
           }     

    }

    void Update()
    {
        
    }

   
   
}
