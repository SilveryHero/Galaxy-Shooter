using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehaviour : MonoBehaviour
{
    private float time;
    private float mov = 0.0f;
    [SerializeField]
    private int _speed;
    public int life = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        time = Time.timeSinceLevelLoad;
    }

    private void Moviment(){   
        
        int _randomX = 0;
        if (time > mov) // mov = cooldown para mudar a direção do movimento
        {
            _randomX = (UnityEngine.Random.Range(-4, 4)); 
            _speed = _randomX * 10;
            mov = time + 1;
        }
                 
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (transform.position.x > 50)
        {
            transform.position = new Vector3(-50, transform.position.y, 0);
        }
         else if (transform.position.x < -50)
        {
            transform.position = new Vector3(50, transform.position.y, 0);
        }

        }
        
}
