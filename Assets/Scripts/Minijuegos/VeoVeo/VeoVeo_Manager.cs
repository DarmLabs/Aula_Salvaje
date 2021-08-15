using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VeoVeo_Manager : MonoBehaviour
{
    int numeroPlantillas;
    GameObject actualPlantillaPrefab;
    public GameObject actualPlantilla;
    void Start()
    {
        StartCoroutine(spawnAfterTime(5));
    }
    public int intentos = 3;
    public Text textIntentos;
    public void SpawnRandomPlantilla()
    {
        numeroPlantillas = Random.Range(1,6);
        actualPlantillaPrefab = Resources.Load("Minijuegos/VeoVeo/Plantilla_"+numeroPlantillas.ToString()) as GameObject;
        actualPlantilla = Instantiate (actualPlantillaPrefab, Vector3.zero, Quaternion.identity, gameObject.transform);
        actualPlantilla.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,0,0);
        textIntentos.gameObject.SetActive(true);
    }
    public void selectCard()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "Correcto")
        {
            GetComponent<MiniGame_Manager>().Win_miniGame();
        }
        else
        {
            intentos = intentos - 1;
            textIntentos.text = ("INTENTOS: "+intentos.ToString());
            if(intentos == 0)
            {
                GetComponent<MiniGame_Manager>().Lose_miniGame();
            }
        }
    }
    public void RestartVeoWin()
    {
        intentos = 3;
        textIntentos.text = ("INTENTOS: "+intentos.ToString());
    }
    IEnumerator spawnAfterTime(int secs)
    {
        yield return new WaitForSecondsRealtime(secs);
        SpawnRandomPlantilla();
    }
}
