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
        gameManager.Spawn.GetComponent<CircleCollider2D>();
        rb = gameManager.player.gameObject.GetComponent<Rigidbody2D>();
        
        //Shop_ui = GameObject.FindGameObjectWithTag("Shop_Ui");
    }

    public void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject == gameManager.player){
            //once player has got to the goal, setting all UI elements and resetting player to start location.
            gameManager.player.gameObject.transform.position = gameManager.Start_Spawn.gameObject.transform.position;
            gameManager.player.gameObject.transform.rotation = gameManager.Start_Spawn.gameObject.transform.rotation;
            
            gameManager.player.gameObject.SetActive(false);
            gameManager.Grid.gameObject.SetActive(false);
            gameManager.Card_ui.gameObject.SetActive(false);
            gameManager.Shop_ui.gameObject.SetActive(true);
        }
    }
}
   

       

