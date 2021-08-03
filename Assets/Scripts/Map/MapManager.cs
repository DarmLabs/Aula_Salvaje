using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public string currentProvincia;
    public bool Zoom = false;

    void Start()
    {
        
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0) && !Zoom)
            {
                if(hit.transform.gameObject.tag == "Provincia")
                {
                    currentProvincia = hit.transform.gameObject.name;
                    GetComponent<Animator>().Play(currentProvincia);
                    Zoom = true;
                    GetComponent<UI_Manager>().TurnOffText();
                }
            }
        }
        if(Zoom)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GetComponent<Animator>().Play(currentProvincia + " 0");
                StartCoroutine(zoomOutEnds(1));
            }
        }
    }
    IEnumerator zoomOutEnds(int secs)
    {
        yield return new WaitForSeconds(secs);
        Zoom = false;
        GetComponent<UI_Manager>().TurnOnText();
    }
}
