using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Comidas;
    public Transform[] spawnPoints;
    private int indexComidas = 12;
    private int indexSpawnpos = 7;

    //private float timeSpawn = 3f;

    
    void Start () 
    {
        InvokeRepeating("invocarComida", 0.3f, 0.7f);
    }

    void Update()
    {
        
    }

    void invocarComida ()
    {
        Instantiate(Comidas[Random.Range(0,indexComidas)],spawnPoints[Random.Range(0,indexSpawnpos)].position,transform.rotation);
    }
   

    
}
