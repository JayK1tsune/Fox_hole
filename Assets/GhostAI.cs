using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public float speed;

    private Transform target;
    MainMenu mainMenu;
    [SerializeField] public GameObject mm;
    [SerializeField] private float _maxhealth = 5;
    [SerializeField] Animator animator;
    private float _currentHealth;
    private BoxCollider2D bc;
    private bool _isDead = false;
    
    [SerializeField] private HealthBar _healthbar;
    
    [SerializeField] GameObject player;
    private void Awake() {
        mainMenu = mm.GetComponent<MainMenu>();
        animator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Start() {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _currentHealth = _maxhealth;
        _healthbar.UpdateHealthBar(_maxhealth,_currentHealth);
        

    }
    private void Update() {
        if(player != null && _isDead == false){
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        }
        if(player == null){
            //play animation when dead
            
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(GameObject.FindGameObjectWithTag("Player")){
            
            //mainMenu.Gameover();
            if (_currentHealth <= 0){
                _isDead = true;                
                animator.SetTrigger("_isDead");
                bc.isTrigger=false;
                Destroy(gameObject,3f);
            }
            else{
                _currentHealth--;
                _healthbar.UpdateHealthBar(_maxhealth,_currentHealth);
            }
            
            //Enter Game Over Screen after i make it.

            Debug.Log("fox");
        }
        
    
    }

}
