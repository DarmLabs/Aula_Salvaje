using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenguaDraw : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;  

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    public List<Vector2> fingerPositions;

    public GameObject inicioLine;
    private bool singleLine=true;
    private bool unavez = false;
    void Start()
    {
        
    }
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(tempFingerPos,fingerPositions[fingerPositions.Count-1])>.1f)
            {
                if (ReglasLengua.regresar == true)
                {
                    Debug.Log("VUELVE A 0");                   
                    singleLine=true;
                    if(!unavez)
                        {
                            currentLine=Instantiate(linePrefab,Vector3.zero,Quaternion.identity);
                            lineRenderer= currentLine.GetComponent<LineRenderer>();
                            edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
                            fingerPositions.Clear();
                            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                            lineRenderer.SetPosition(0,inicioLine.transform.position);
                            //lineRenderer.SetPosition(0,fingerPositions[0]);
                            lineRenderer.SetPosition(1,inicioLine.transform.position);
                            edgeCollider.points = fingerPositions.ToArray();
                            unavez =true;
                        }
                               
                    

                    
                    
                }
                else
                {
                    UpdateLine(tempFingerPos); 
                }              

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Pressed left click.");
            singleLine=false;
        }
    }
    void CreateLine()
    {
        if(singleLine)
        {
        currentLine=Instantiate(linePrefab,Vector3.zero,Quaternion.identity);
        lineRenderer= currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0,inicioLine.transform.position);
        //lineRenderer.SetPosition(0,fingerPositions[0]);
        lineRenderer.SetPosition(1,fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
        }
        
    }
    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
    }
    

}
