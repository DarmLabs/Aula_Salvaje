using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool dragging = false;
    private float distance; 
    private int countCorrect = 0;
    private int countIncorrect = 0;
   
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
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
 
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Entro");
        if (other.gameObject.tag == "Alimentacion" && other.gameObject.name == this.gameObject.tag)
        {
            Destroy(this.gameObject);
            countCorrect+=1;
        }
        if (dragging == false)
        {
            if (other.gameObject.tag == "Alimentacion" && other.gameObject.name != this.gameObject.tag)
            {
                Destroy(this.gameObject);
                countIncorrect+=1; 
            }
        }
    }



    
}
