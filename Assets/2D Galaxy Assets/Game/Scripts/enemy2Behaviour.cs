using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Behaviour : MonoBehaviour
{
    private float time;
    [SerializeField]
    public int lives = 1;
    private float _enemySpeed = 25.0f;
    private float aumento = 0;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad;
        Moviment();
        Destruction();
        
    }

    private void Moviment(){   
        
        if (time > aumento){
        _enemySpeed = _enemySpeed + 10.0f;   
        aumento = time + 7.0f; 
        }    
        if (player != null){
        Player target = player.GetComponent<Player>();
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        if (transform.position.y >= target.transform.position.y){
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _enemySpeed * Time.deltaTime);  
        }
        }
        else if (player == null){
           
        return;

        } 

        else{
                   
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        }
        } 

        private void Destruction(){
        
        if (transform.position.y < -44)
        {
            float _randomX = UnityEngine.Random.Range(-27.0f, 27.0f);
            transform.position = new Vector3(_randomX, 44, 0);
        }
       
        
    }
    


}