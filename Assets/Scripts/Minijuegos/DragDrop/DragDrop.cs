using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool dragging = false;
    private float distance; 
    public static int countCorrect = 0;
    public static int countIncorrect = 0;
    public int totalCount = 0;
    public GameObject objManager;
    public GameObject[] visualFeedbacks;
    
    void Start()
    {        
        objManager = GameObject.Find("Canvas Overlay");
        //se inician los contadores para evitar errores
        countCorrect=0;
        countIncorrect=0;
    }
    void Update()
    {
        //toca las cartas en base a un raycast
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0f;
            transform.position = rayPoint;
        }
        condicionVictoria();
        
    } 
    
    void OnMouseDown()
    {
        //al hacer clic se arrastra la carta
        if(Time.timeScale != 0)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
        }
    }
 
    void OnMouseUp()
    {
        dragging = false;
    } 
   
    void OnCollisionStay(Collision other) 
    {               
        //cuando se suelta la carta se comprueba si fue arrastrado a la posicion correcta, se suman los contadores correspondientes
        if (dragging == false)
        {
            if (other.gameObject.tag == "Alimentacion" && other.gameObject.name != this.gameObject.tag)
            {
                countIncorrect+=1;         
                Destroy(this.gameObject);                
                GameObject Mal = Instantiate(visualFeedbacks[1],other.gameObject.transform.position,transform.rotation);
                Destroy(Mal,0.4f);
            }            
            if (other.gameObject.tag == "Alimentacion" && other.gameObject.name == this.gameObject.tag)
            {
                countCorrect+=1;               
                Destroy(this.gameObject);               
                GameObject Bien = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,transform.rotation);
                Destroy(Bien,0.4f);   
            }
        } 
    }  
    //se comprueba que las 5 cartas dadas hayan sido utilizadas
    void condicionVictoria()
    {
        totalCount = countCorrect+countIncorrect;
       
        if (totalCount == 5)
        {
            if (countIncorrect>countCorrect)
            {
                objManager.GetComponent<MiniGame_Manager>().Lose_miniGame();
            }
            if (countCorrect>countIncorrect)
            {
                objManager.GetComponent<MiniGame_Manager>().Win_miniGame(); 
            }
           
        }
    }
   


    
}
