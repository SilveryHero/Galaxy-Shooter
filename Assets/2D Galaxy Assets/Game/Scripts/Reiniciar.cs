using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reiniciar : MonoBehaviour
{
   private void Start() {
    
   }

   private void Update() {
    
    if (Input.GetKeyDown(KeyCode.Return)){
        SceneManager.LoadScene("PressStart");  
    }
   
    else if (Input.GetKeyDown(KeyCode.Escape)){

        Application.Quit();  
        }
   

   
}
}
