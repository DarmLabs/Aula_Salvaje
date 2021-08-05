using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public string currentProvincia;
    public bool Zoom = false;
    bool canPressButton = true;
    GameObject selectedObject;

    void Start()
    {
        
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0) && !Zoom && canPressButton)
            {
                if(hit.transform.gameObject.tag == "Provincia")
                {
                    canPressButton = false;
                    currentProvincia = hit.transform.gameObject.name;
                    selectedObject = hit.transform.gameObject;
                    selectedObject.GetComponent<UnitManager>().OnDeactivation();
                    GetComponent<Animator>().Play(currentProvincia);
                    GetComponent<UI_Manager>().TurnOffText();
                    Zoom = true; 
                    StartCoroutine(zoomInEnds(1));
                }
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Escape) && Zoom && canPressButton)
        {
            canPressButton = false;
            GetComponent<Animator>().Play(currentProvincia + " 0");
            GetComponent<UI_Manager>().SelectionOff();
            StartCoroutine(zoomOutEnds(1));
        }
        
    }
    IEnumerator zoomOutEnds(int secs)
    {
        yield return new WaitForSeconds(secs);
        Zoom = false;
        canPressButton = true;
        selectedObject.GetComponent<UnitManager>().OnReactivation();
        GetComponent<UI_Manager>().TurnOnText();
    }
    
    IEnumerator zoomInEnds(int secs)
    {
        yield return new WaitForSeconds(secs); 
        GetComponent<UI_Manager>().SelectionOn();
        canPressButton = true;      
    }
}
