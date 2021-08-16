using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool dragging = false;
    private float distance; 
    private int countCorrect = 0;
    private int countIncorrect = 0;

    public GameObject[] visualFeedbacks;
   
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0f;
            transform.position = rayPoint;
        }
    } 
    
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
 
    void OnMouseUp()
    {
        dragging = false;
    } 
   
    void OnCollisionStay(Collision other) 
    {
        if (countCorrect+countIncorrect == 5)
        {
            if (countIncorrect>countCorrect)
            {
                //Perdió
            }
            else
            {
                //Ganó
            }
        }
        if (dragging == false)
        {
            if (other.gameObject.tag == "Alimentacion" && other.gameObject.name != this.gameObject.tag)
            {
                Destroy(this.gameObject);
                countIncorrect+=1; 
                GameObject Mal = Instantiate(visualFeedbacks[1],other.gameObject.transform.position,transform.rotation);
                Destroy(Mal,0.4f);
            }
            
            if (other.gameObject.tag == "Alimentacion" && other.gameObject.name == this.gameObject.tag)
            {
                Destroy(this.gameObject);
                countCorrect+=1;
                GameObject Bien = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,transform.rotation);
                Destroy(Bien,0.4f);   
            }
        } 
    }
   


    
}
