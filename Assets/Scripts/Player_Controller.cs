using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
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
    }
    

    
 
    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();

    }
}
