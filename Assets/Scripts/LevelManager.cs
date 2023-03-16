using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawnPlayer(){
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo(){
        AnimacionPersonaje.instance.anim.SetTrigger("muerto"); //animacion de muerte
        AnimacionPersonaje.instance.gameObject.SetActive(false); //se desactiva el jugador al morir
        yield return new WaitForSeconds(waitToRespawn); //segundos para respaunear
        AnimacionPersonaje.instance.gameObject.SetActive(true); //despues del respawn se reactiva el jugador
        AnimacionPersonaje.instance.transform.position = CheckPointController.instance.spawn; //respaunea en la ultima posicion de chackpoint
        VidaDelJugador.instance.vida = VidaDelJugador.instance.maxVida;
        UIController.instance.updateVidas();
    }

    public void EndLevel(){

    }
}
