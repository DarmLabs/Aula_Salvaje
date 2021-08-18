using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReglasLengua : MonoBehaviour
{
    // Start is called before the first frame update
    private int contadorHormigas;
    public static bool regresar = false;
    public GameObject[] feedback;
    public GameObject referencia;
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void Update()
    {
    }
        

    void OnCollisionEnter2D(Collision2D other) 
    {
       Debug.Log("Colisiono con:   "+other.gameObject.name+"  "+other.gameObject.tag);
       if (other.gameObject.tag =="Alimentacion")
       {
            GameObject Bien = Instantiate(feedback[0],referencia.transform.position,Quaternion.identity);
            Destroy(Bien,0.4f);
            Destroy(other.gameObject);
            contadorHormigas+=1;
            regresar = true;
            Destroy(this.gameObject);
            Debug.Log("Hormigas comidas:   "+contadorHormigas);
       }
        if  (other.gameObject.tag =="Pared")     
        {
            GameObject Mal = Instantiate(feedback[1],referencia.transform.position,Quaternion.identity);
            Destroy(Mal,0.4f);
            regresar = true;
            Destroy(this.gameObject);
       }
    }

    
}
