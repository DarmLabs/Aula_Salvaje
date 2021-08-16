using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObs : MonoBehaviour
{
    public GameObject[] obstaculos;
    public Transform[] spawnPoints;
    private int indexObstaculos = 4;
    private int indexRandom;   


    
    void Start () 
    {       
           for (int i = 0; i < 23; i++)
           {
                indexRandom = Random.Range(0,indexObstaculos);        
                Instantiate(obstaculos[indexRandom],spawnPoints[i].position,transform.rotation);               
           }     

    }

}
