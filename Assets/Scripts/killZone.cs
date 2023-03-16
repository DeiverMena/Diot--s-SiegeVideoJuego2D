using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){ //matar al jugador y respaunea en el ultimo cheackpoint o inicio del juego
            LevelManager.instance.respawnPlayer();
        }
    }
}
