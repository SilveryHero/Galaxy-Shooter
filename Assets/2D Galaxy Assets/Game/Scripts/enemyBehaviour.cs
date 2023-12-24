using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    private float time;
    [SerializeField]
    private float _enemySpeed = 20.0f;
    private float aumento = 0.0f;
    public int lives = 1;
   // Start is called before the first frame update
    void Start()
    {

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
          
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        }
        

    private void Destruction(){
        
        if (this.gameObject.tag == "Explosion")
        {
            if (transform.position.y < -44)
        {
            Destroy(this.gameObject);
        }
        }
        else if (transform.position.y < -44)
        {
            float _randomX = UnityEngine.Random.Range(-27.0f, 27.0f);
            transform.position = new Vector3(_randomX, 44, 0);
        }
       
        
    }
}
