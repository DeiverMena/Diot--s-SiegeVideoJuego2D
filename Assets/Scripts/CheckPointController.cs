using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;
    public CheckPoint[] checkPoints; //matriz en la que iran los checkpoints de un niveñ

    public Vector3 spawn;

    void Awake()
    {
        instance = this;
    }

    void Start(){
        checkPoints = FindObjectsOfType<CheckPoint>(); //se buscan los check pints en la escenaS
        spawn = AnimacionPersonaje.instance.transform.position; //punto inicial del juego

    // Update is called once per frame
    }

      public void DeactivateCheckPoint(){ //se desactivan los checkpoint cada que se golpea uno nuevo
        for(int i = 0; i < checkPoints.Length; i++){
            checkPoints[i].ResetCheckPoint();
        }
    }

    public void SetSpawn(Vector3 newspawn){
        spawn = newspawn;
    }

   
}
