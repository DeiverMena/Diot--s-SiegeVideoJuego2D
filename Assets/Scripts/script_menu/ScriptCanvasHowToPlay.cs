using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptCanvasHowToPlay : MonoBehaviour {
   
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

     public void clickButtonVolver() {
       SceneManager.LoadSceneAsync("MainScene");
    }

    
}
