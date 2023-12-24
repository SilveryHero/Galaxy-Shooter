using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float _canFire = 0.0f;
    public int playerLives = 3;
    public bool tripleShot = false;
    public bool shield = false;
    [SerializeField]
    private float time;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemy2;
    [SerializeField]
    private GameObject _boss;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _playerExplosionPrefab;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;
    [SerializeField]
    private GameObject _powerUp0;
     [SerializeField]
    private GameObject _powerUp1;
    [SerializeField]
    private GameObject _powerUp2;
    [SerializeField]
    private float _speed = 50.5f;
    [SerializeField]
    private float _fireRate = 0.3f;
    [SerializeField]
    private float _tripleShotUpTime = 10.0f;
    [SerializeField]
    private float _speedBoostUpTime = 8.0f;
    [SerializeField]
    private float _shieldUpTime = 15.0f;
    [SerializeField]
    private float _enemySpawnTime = 3.0f;
    [SerializeField]
    private float _enemy2SpawnTime = 5.0f;
    private UIManager _uiManager;
    
    // Start is called before the first frame update
    public void Start()
    {
        
        transform.position = new Vector3(0, 0, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
        if (_uiManager != null){

            _uiManager.UpdateLives(playerLives);

        } 
    }

    // Update is called once per frame
    public void Update()
    {
        time = Time.timeSinceLevelLoad;
        Moviment();
        Laser();
        TripleShotPowerUp();
        SpeedBoostPowerUp();
        ShieldPowerUp();
        EnemySpawn();
        Enemy2Spawn();
        BossSpawn();
        if (Input.GetKeyDown(KeyCode.Escape)){

        Application.Quit();
        }
            
    }

    private void OnTriggerEnter2D (Collider2D other){

    if (other.tag == "Enemy"){
        
        GameObject _derrotado = other.gameObject;
        Destroy(other.gameObject);
        Instantiate(_enemyExplosionPrefab, _derrotado.transform.position, Quaternion.identity);
        if (shield == true){
            shield = false;
            _shieldGameObject.SetActive(false);
        }
        else {
            playerLives = playerLives - 1;
            _uiManager.UpdateLives(playerLives);
            
        }
        if (playerLives == 0)
        {
            Instantiate(_playerExplosionPrefab, transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
                       
                                                
        }
        }
    }

    private void Moviment(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
         else if (transform.position.y < -30)
        {
            transform.position = new Vector3(transform.position.x, -30, 0);
        }

        if (transform.position.x > 57)
        {
            transform.position = new Vector3(57, transform.position.y, 0);
        }
         else if (transform.position.x < -57)
        {
            transform.position = new Vector3(-57, transform.position.y, 0);
        }
    }
    private void Laser(){
       
        if ((Time.time > _canFire && tripleShot == (true)) && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))){
            
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            _canFire = Time.time+_fireRate;
        }
        
       
        else  if(Time.time > _canFire && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))){
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 7, 0), Quaternion.identity);
            _canFire = Time.time+_fireRate;
        }
    
        }
    private void TripleShotPowerUp(){
        float _randomX = UnityEngine.Random.Range(-47.0f, 47.0f);
        
        if (Time.time >= _tripleShotUpTime) 
        {
            Instantiate(_powerUp0, new Vector3(_randomX, 39, 0), Quaternion.identity);
            _tripleShotUpTime = Time.time + 10.0f;
        }
    }

    private void SpeedBoostPowerUp(){
        float _randomX = UnityEngine.Random.Range(-47.0f, 47.0f);
        
        if (Time.time >= _speedBoostUpTime) 
        {
            Instantiate(_powerUp1, new Vector3(_randomX, 39, 0), Quaternion.identity);
            _speedBoostUpTime = Time.time + 8.0f;
        }
    }
    
    private void ShieldPowerUp(){
        float _randomX = UnityEngine.Random.Range(-47.0f, 47.0f);
        
        if (Time.time >= _shieldUpTime) 
        {
            Instantiate(_powerUp2, new Vector3(_randomX, 39, 0), Quaternion.identity);
            _shieldUpTime = Time.time + 15.0f;
        }
    }

    private void EnemySpawn(){
        
        float _randomX = UnityEngine.Random.Range(-47.0f, 47.0f);
        if (_uiManager.scoretotal < 30 || _uiManager.scoretotal >= 40) 
        {
            if (Time.time >= _enemySpawnTime) 
        {
            Instantiate(_enemy, new Vector3(_randomX, 44, 0), Quaternion.identity);
            _enemySpawnTime = Time.time + 3.0f;
                    
        }
        }
    }

    private void Enemy2Spawn(){
        
        float _randomX = UnityEngine.Random.Range(-47.0f, 47.0f);
        if (_uiManager.scoretotal >=20 && _uiManager.scoretotal < 30 || _uiManager.scoretotal >= 40 )
        {
            
            if (Time.time >= _enemy2SpawnTime) 
        {
            Instantiate(_enemy2, new Vector3(_randomX, 44, 0), Quaternion.identity);
            _enemy2SpawnTime = Time.time + 5.0f;
                    
        }
        }
    }

    private void BossSpawn(){
        
        if (_uiManager.scoretotal == 30 || _uiManager.scoretotal == 60 )
        {
            Instantiate(_boss, new Vector3(0, 24, 0), Quaternion.AngleAxis(180, Vector3.right));
            _uiManager.scoretotal++;
        }
        }
    

    public void TripleShotOn(){

        tripleShot = true;
        StartCoroutine(TripleShotCoolDown());
    }

    public void SpeedBoostOn(){
        _speed = _speed * 1.5f;
        StartCoroutine(SpeedBoostCoolDown());
    }

    public void ShieldOn(){

        shield = true;
        _shieldGameObject.SetActive(true);
        StartCoroutine(ShieldCoolDown());
       
    }
           
    public IEnumerator TripleShotCoolDown(){

        yield return new WaitForSeconds(4.0f);
        tripleShot = false;
    
    }
    public IEnumerator SpeedBoostCoolDown(){

        yield return new WaitForSeconds(4.0f);
        _speed = _speed/1.5f;
    }
    public IEnumerator ShieldCoolDown(){

        yield return new WaitForSeconds(10.0f);
        shield = false;
        _shieldGameObject.SetActive(false);
    }
   
    
}
    


