using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Player_Controller : MonoBehaviour,IPointerDownHandler
{
    public Animator animator;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.5F;
    public ContactFilter2D movementFilter;
    public float MaxMovment = 1f;
    PauseMenu pauseMenu;
    [SerializeField] GameObject pm;

    Vector2 movementInput;

    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private void Awake() {
        pauseMenu = pm.GetComponent<PauseMenu>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
    public void OnPointerDown(PointerEventData eventData)
    {
            Debug.Log("I'm teh Fox");
    
    }
    void OnEsc(){
        if(pauseMenu.GameIsPaused == false){
            pauseMenu.Pause();           
        }
        else{
            pauseMenu.Resume();
        }
        Debug.Log("I pressed Esc");
    }


}
