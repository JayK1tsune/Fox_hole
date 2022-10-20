using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.5F;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;

    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
