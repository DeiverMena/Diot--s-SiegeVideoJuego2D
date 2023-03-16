using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDelJugador : MonoBehaviour
{

    public static VidaDelJugador instance; // cuando se declara una intancia se debe usar la funcion awake
    // Start is called before the first frame update
    public int vida, maxVida, muerto; // vida actual y vida maxima
    public float invincibleLenght;
    public float invincibleCounter;

    private SpriteRenderer invisibleSprite; // le hacen daño al jugador el sprite se hace transparente por un tiempo
    public static bool muerte;
    private void Awake(){
        instance = this; //ahora se puede usar esta clase y sus fuinciones desde otros scripts
    }
    void Start()
    {
        muerte = false;
        vida = maxVida; //siempre inicia con la vida maxima
        invisibleSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0){
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0){
                invisibleSprite.color = new Color(invisibleSprite.color.r,invisibleSprite.color.g, invisibleSprite.color.b, 1f );
            }
        }
    }

    //Funcion de daño al jugador
    public void daño(){
        if(invincibleCounter <= 0){
            vida --; 
            AnimacionPersonaje.instance.anim.SetTrigger("daño"); //animacion de daño
            if(vida <= 0){
                vida = 0;
                    if(vida == 0){
                        personajeMuerto();
                    }  
                }else{
                    invincibleCounter = invincibleLenght;
                    invisibleSprite.color = new Color(invisibleSprite.color.r,invisibleSprite.color.g, invisibleSprite.color.b, 0.5f );
                    AnimacionPersonaje.instance.Knockback();
            }

        }
        UIController.instance.updateVidas();
    }

    public void curar(){
        vida++;
        if(vida > maxVida){
            vida = maxVida;
        }
        UIController.instance.updateVidas();
    }

    public void personajeMuerto(){ //no funciona la muerte, aun desaparece con el spawn, quiza el problema sea la animacion
        AnimacionPersonaje.instance.anim.SetBool("murio",true);
        Debug.Log("aqui");
        LevelManager.instance.respawnPlayer(); //el jugaor con 0 vidas rspaunea con vidas completas
    }

    
}
