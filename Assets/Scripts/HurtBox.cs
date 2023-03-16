using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public float counter = 0;
    [Range(0,100)]public float chanceToDroop;
    public GameObject collectible;
    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Enemy" ){
            counter++;
            
            Debug.Log("golpe:"+counter);
            if(counter >= 3){
                Debug.Log("enemigo eliminado");
                other.transform.parent.gameObject.SetActive(false);
                AnimacionPersonaje.instance.Bounce();
                counter = 0;
            }

        }else if(other.tag == "semiEnemy"){

            Debug.Log("semi enemigo golpeado");
            other.transform.parent.gameObject.SetActive(false);
            AnimacionPersonaje.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if(dropSelect <= chanceToDroop){
                Instantiate(collectible, other.transform.position, other.transform.rotation);

            }
        }
    }
}
