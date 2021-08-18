using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Comidas;
    public Transform[] spawnPoints;
    private int indexComidas = 12;
    private int indexSpawnpos = 7;
    public float timeSpawn = 1f;

    
    void Start () 
    {
        //se instancia la comida que cae, con una diferencia de tiempo, lo hace aleatoriamente
        InvokeRepeating("invocarComida", 0.3f, timeSpawn);
        
    }

    void Update()
    {
        
    }

    void invocarComida ()
    {
        Instantiate(Comidas[Random.Range(0,indexComidas)],spawnPoints[Random.Range(0,indexSpawnpos)].position,transform.rotation);
    }
   

    
}
