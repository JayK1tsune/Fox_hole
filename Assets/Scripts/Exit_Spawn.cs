using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject player;
    public GameObject Shop_ui;
    public GameObject Card_ui;
    [SerializeField] private GameObject Start_Spawn;
    [SerializeField] GameObject Grid;
    Rigidbody2D rb;

   

    void Awake()
    {
        Spawn.GetComponent<CircleCollider2D>();
        rb = player.gameObject.GetComponent<Rigidbody2D>();
        
        //Shop_ui = GameObject.FindGameObjectWithTag("Shop_Ui");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject == player){
            //once player has got to the goal, setting all UI elements and resetting player to start location.
            player.gameObject.transform.position = Start_Spawn.gameObject.transform.position;
            player.gameObject.transform.rotation = Start_Spawn.gameObject.transform.rotation;
            
            player.gameObject.SetActive(false);
            Grid.gameObject.SetActive(false);
            Card_ui.gameObject.SetActive(false);
            Shop_ui.gameObject.SetActive(true);
        }
    }
        public void NewLevel(){
            player.gameObject.SetActive(true);
            rb.velocity = new Vector2();
            Grid.gameObject.SetActive(true);
            Card_ui.gameObject.SetActive(true);
            Shop_ui.gameObject.SetActive(false);
    }
}
   

       

