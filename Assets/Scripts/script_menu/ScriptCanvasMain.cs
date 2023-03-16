using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptCanvasMain : MonoBehaviour {
    // Start is called before the first frame update

    void Start() {
      
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void clickButtonPlay() {
        SceneManager.LoadSceneAsync("PlayScene");
    }

    public void clickButtonHowToPlay() {
        SceneManager.LoadSceneAsync("HowToPlayScene"); 
    }
}
