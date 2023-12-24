using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    private float _changeScene = 0.0f;
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
         _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_uiManager.scoretotal >= 70) {
            SceneManager.LoadScene("Winner");
        }
        if (gameOver != null){
        Player player = gameOver.GetComponent<Player>();

        if (player == null){
           
                SceneManager.LoadScene("GameOver");

        } 
        else if (player.playerLives == 0){

            SceneManager.LoadScene("GameOver");                
            }
        }
        else {
        StartCoroutine(GameOverScene());
            if ( _changeScene > Time.time){
                SceneManager.LoadScene("GameOver");
            }         
        }

        }
   
    public IEnumerator GameOverScene(){

        yield return new WaitForSeconds(2.0f);
        _changeScene = Time.time + 100.0f;
    }

    


}
