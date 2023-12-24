using System.Diagnostics;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBehavior : MonoBehaviour
{
    [SerializeField]
    private int _laserSpeed;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    [SerializeField]
    private GameObject _playerExplosionPrefab;
    private UIManager _uiManager;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
       _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
 
    }

    // Update is called once per frame
    void Update()
    {
       
       _laserSpeed = 50;
       transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
       if (transform.position.y >= 39)
        {
            Destroy(this.gameObject);
            
        }
        
    }
    private void OnTriggerEnter2D (Collider2D other){

    if (other.tag == "Enemy")
    {
        GameObject _derrotado = other.gameObject;
        Destroy(other.gameObject);
        _uiManager.UpdateScore();
        Instantiate(_enemyExplosionPrefab, _derrotado.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

     if (other.tag == "Boss"){
        
        bossBehaviour _derrotado =other.GetComponent<bossBehaviour>();;
        _derrotado.life--;
        if (_derrotado.life ==0){
            Destroy(other.gameObject);
            _uiManager.scoretotal = _uiManager.scoretotal + 10;
            _uiManager.UpdateScore();
            Instantiate(_playerExplosionPrefab, _derrotado.transform.position, Quaternion.AngleAxis(180, Vector3.right));
            Destroy(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
     }
}
}
