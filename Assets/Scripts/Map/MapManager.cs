using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public string currentProvincia;
    public bool Zoom = false;
    GameObject selectedObject;
    public GameObject textReader;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0) && !Zoom)//usando raycast selecciono una provincia si no hay otra seleccionada
            {
                if(hit.transform.gameObject.tag == "Provincia")
                {
                    currentProvincia = hit.transform.gameObject.name;
                    selectedObject = hit.transform.gameObject;
                    selectedObject.GetComponent<UnitManager>().OnAsigned();
                    GetComponent<Animator>().Play(currentProvincia);
                    GetComponent<UI_Manager>().TurnOffText();
                    GetComponent<UI_Manager>().InfoPanelOn();
                    Zoom = true; 
                    StartCoroutine(zoomInEnds(1));
                }
            }
        } 
    }
    IEnumerator zoomOutEnds(int secs)//esta funcion activa 
    {
        yield return new WaitForSeconds(secs);
        Zoom = false;
        selectedObject.GetComponent<UnitManager>().OffAsigned();
        GetComponent<UI_Manager>().TurnOnText();
        GetComponent<UI_Manager>().InfoPanelOff();
    }
    
    IEnumerator zoomInEnds(int secs)//activo funciones en el ui manager
    {
        yield return new WaitForSeconds(secs); 
        GetComponent<UI_Manager>().SelectionOn(); 
        GetComponent<UI_Manager>().exitMapButtonOn();   
    }
    
    public void zoomOut()//esta funcion se activa presionando X para salir de la seleccion de una provincia
    {
        if (Zoom)
        {
            GetComponent<UI_Manager>().exitMapButtonOff();
            GetComponent<Animator>().Play(currentProvincia + " 0");
            GetComponent<UI_Manager>().SelectionOff();
            textReader.GetComponent<TextReader>().ClearTexts();
            StartCoroutine(zoomOutEnds(1));
        }
    }
}
