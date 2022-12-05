
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour,IPointerDownHandler
{
    public Animator animator;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.5F;
    public ContactFilter2D movementFilter;
    public float MaxMovment = 1f;
    HealthBar healthBar;
    GameManager gameManager;
    public bool _ghostCanHit;
    [SerializeField] GameObject hb;
    private float _health;
    [SerializeField] float _maxhealth;
    [SerializeField] GameObject gm;
    [SerializeField] GameObject _cards;
    public GameObject[] _ghost;
    public GameObject _ghostPrefab;
    Card card;
  

    Vector2 movementInput;

    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();


    void Start()
    {
        healthBar = hb.GetComponent<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _health = _maxhealth;
        gameManager = gm.GetComponent<GameManager>();
        card = _cards.GetComponent<Card>();
    }
    void OnDisable(){
        movementInput = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero){
            rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
        }
        rb.velocity = movementInput * moveSpeed;
    }
  
    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
        if(movementInput != Vector2.zero){
            animator.SetBool("Ismoving", true);
            animator.SetFloat("Xinput",movementInput.x);
            animator.SetFloat("Yinput", movementInput.y);
        }
        else animator.SetBool("Ismoving",false);
        
    }
    public void OnEsc(){
        if(gameManager.pauseMenu.GameIsPaused == false){
            gameManager.pauseMenu.Pause();           
        }
        else{
            gameManager.pauseMenu.Resume();
        }
        Debug.Log("I pressed Esc");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
            Debug.Log("I'm teh Fox");
    
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {  
        if(collider.CompareTag("Ghost")){
            if (_health <= 0){
                
                Destroy(gameObject,3f);
                SceneManager.LoadScene("GameOver");
                

            }
            else if (!gameManager.canAttack){
                _health--;
                Debug.Log(_ghostCanHit);
                healthBar.UpdateHealthBar(_maxhealth,_health);
            }
        }
    }
}
