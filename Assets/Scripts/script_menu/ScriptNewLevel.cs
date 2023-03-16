using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptNewLevel : MonoBehaviour
{
     // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void clickButtonVolver() {
        SceneManager.LoadSceneAsync("MainScene");
    }

   public void clickButtonEuropa() {
        SceneManager.LoadSceneAsync("JuegoNivelUno");
    }
}
