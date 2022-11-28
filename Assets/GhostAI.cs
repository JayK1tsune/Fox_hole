using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public float speed;

    private Transform target;
    MainMenu mainMenu;
    [SerializeField] public GameObject mm;
    
    [SerializeField] GameObject player;
    private void Awake() {
        mainMenu = mm.GetComponent<MainMenu>();
    }

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        

    }
    private void Update() {
        if(player != null){
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        }
        if(player == null){
            //play animation when dead
            
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(GameObject.FindGameObjectWithTag("Player")){
            
            mainMenu.Gameover();
            
            //Enter Game Over Screen after i make it.

            Debug.Log("fox");
        }
        
    
    }

}
