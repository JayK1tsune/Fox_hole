using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Spawn : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject game;

    Rigidbody2D rb;

   

    void Awake()
    {
        gameManager = game.GetComponent<GameManager>();
        gameManager._spawn.GetComponent<CircleCollider2D>();
        rb = gameManager.player.gameObject.GetComponent<Rigidbody2D>();
        
        //Shop_ui = GameObject.FindGameObjectWithTag("Shop_Ui");
    }

    public void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject == gameManager.player){
            //once player has got to the goal, setting all UI elements and resetting player to start location.
            gameManager.ShopEnter();
            
        }
    }
}
   

       

