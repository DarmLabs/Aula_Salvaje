using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float velocidadV = 10f;
    
    [SerializeField]
    private float velocidadH = 5f;
    public GameObject[] visualFeedbacks;

    private int choque = 0;

    public GameObject objManager;
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    void Update()
    {
        Movimiento();       
    }
    void Movimiento()
    {
       
        //float h = Input.GetAxis("Mouse Y");     
        float h =Input.GetAxis("Vertical");     
        rb.velocity = new Vector2(velocidadH,h*velocidadV);
        transform.Rotate(0,0,-(velocidadH/2)); 
        if(choque == 4)
        {
            objManager.GetComponent<MiniGame_Manager>().Lose_miniGame();
        }    
        if (Input.GetKeyDown(KeyCode.Space))
        {
           Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) && Time.timeScale !=0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {         
        Debug.Log(other.gameObject.name);
        switch (other.gameObject.name)
        {
            case "Cactus(Clone)":
            GameObject MalCa = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,Quaternion.identity);
            Destroy(MalCa,0.4f);
            choque += 1;
            velocidadH = velocidadH - 0.3f;
            Destroy(other.gameObject);
            break;
            case "Charco(Clone)":
            GameObject MalCh = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,Quaternion.identity);
            Destroy(MalCh,0.4f); 
            velocidadH = velocidadH - 0.1f;
            Destroy(other.gameObject);
            break;
            case "Piedras(Clone)":
            GameObject MalPi = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,Quaternion.identity);
            Destroy(MalPi,0.4f); 
            choque += 1;
            velocidadH = velocidadH - 0.5f;
            Destroy(other.gameObject);
            break;
            case "Pozo(Clone)":
            choque += 1;
            GameObject MalPo = Instantiate(visualFeedbacks[0],other.gameObject.transform.position,Quaternion.identity);
            Destroy(MalPo,0.4f); 
            velocidadH = velocidadH - 0.4f;
            Destroy(other.gameObject);
            break;
            case "Meta":
            objManager.GetComponent<MiniGame_Manager>().Win_miniGame();
            break;
        }
       
    }


}
