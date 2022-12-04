using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostAI : MonoBehaviour
{
    public float speed;
    private float slowSpeed;
    private Transform target;
    MainMenu mainMenu;
    GameManager gameManager;
    Card card;

    [SerializeField] GameObject _card;
    [SerializeField] GameObject Gm;
    [SerializeField] public GameObject mm;
    [SerializeField] private float _maxhealth = 5;
    [SerializeField] Animator animator;
    [SerializeField] public  Transform _escape;
    private float _currentHealth;
    
    private BoxCollider2D bc;
    private bool _isDead = false;
    private int _deathCount = 4;
    
    [SerializeField] private HealthBar _healthbar;
    
    
    [SerializeField] GameObject player;
    private void Awake() {
        gameManager = Gm.GetComponent<GameManager>();
        mainMenu = mm.GetComponent<MainMenu>();
        animator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        card = _card.GetComponent<Card>();
        
        
    }
    private void OnDisable() {
        if(gameObject == null){
            gameObject.transform.position = _escape.transform.position;
        }
        
    }

    private void Start() {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _escape = _escape.GetComponent<Transform>();
        _currentHealth = _maxhealth;
      
        _healthbar.UpdateHealthBar(_maxhealth,_currentHealth);
        
        slowSpeed = speed / 1 ;
        

    }
    private void Update(){// Checking to see if Player can attack, If so Ghost will "run" away, otherwise will keep chasing player.
        if (gameManager.canAttack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _escape.position,slowSpeed  * Time.deltaTime);
        }

        if (player != null && _isDead == false && gameManager.canAttack == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        if (_deathCount <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }


    }
    // Triggers with Player - Update health bar 
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(GameObject.FindGameObjectWithTag("Player")){
            if (_currentHealth <= 0){
                _isDead = true;                
                animator.SetTrigger("_isDead");
                bc.isTrigger=false;
                gameManager._ghostDeathCount--;
                Debug.Log(_deathCount);
                Destroy(gameObject,3f);

            }
            else if (gameManager.canAttack){
                _currentHealth--;
                _healthbar.UpdateHealthBar(_maxhealth,_currentHealth);
            }
        }
    }
        

        
        
    
  

}
