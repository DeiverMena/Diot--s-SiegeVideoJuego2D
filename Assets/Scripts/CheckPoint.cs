using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer Renderer;

    public Sprite checkpointOff, checkpointOn;
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            CheckPointController.instance.DeactivateCheckPoint();
            Renderer.sprite = checkpointOn;
            CheckPointController.instance.SetSpawn(transform.position); 
        }
    }

    public void ResetCheckPoint(){ //resetea los cheack points
        Renderer.sprite = checkpointOff;
    }
}
