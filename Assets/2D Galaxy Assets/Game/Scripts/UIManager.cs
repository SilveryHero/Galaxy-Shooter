using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesDisplay;
    public Text pontos; 
    public int scoretotal = 0;
  
    public void UpdateLives(int currentLives)
    {
        livesDisplay.sprite = lives[currentLives];
    }


    public void UpdateScore()
    {
        scoretotal ++;
        pontos.text = "Pontos: " + (10* scoretotal);
    } 
        
}
