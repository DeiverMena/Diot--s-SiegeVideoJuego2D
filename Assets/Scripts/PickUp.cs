using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isFruit;
    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !isCollected){//si el personaje toca un pick up y es recolectado
            if(isFruit){ //si el jugador toca una fruta
                if(VidaDelJugador.instance.vida != VidaDelJugador.instance.maxVida){ //si no esta llena la vida
                    VidaDelJugador.instance.curar();

                    isCollected = true;
                    Destroy(gameObject);
                }



            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
