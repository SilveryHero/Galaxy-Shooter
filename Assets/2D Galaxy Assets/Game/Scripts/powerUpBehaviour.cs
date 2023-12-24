using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _powerSpeed = 20;
    [SerializeField]
    private int powerUpID; // 0 == triple shot, 1 == speed boost, 2 == shield
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _powerSpeed * Time.deltaTime);
        if (transform.position.y < -39)
        {
            Destroy(this.gameObject);
            
        }

        
    }
    private void OnTriggerEnter2D (Collider2D other){

    if (other.tag == "Player")
    {
        
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            if (powerUpID ==0)
            {
                player.TripleShotOn();
            }
            
            else if (powerUpID == 1)
            {
               player.SpeedBoostOn();
            }
            else if (powerUpID == 2)
            {
                player.ShieldOn();
            }
        }
        
        Destroy(this.gameObject); 

    }
       
    }
    
}
