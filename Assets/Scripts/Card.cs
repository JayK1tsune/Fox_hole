using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class Card : MonoBehaviour
{
    
    public int handIndex;
    private deck_of_cards doc;
    public bool hasBeenPlayer;

    private void Start(){
        doc = FindObjectOfType<deck_of_cards>();
    }

    void OnClick(){
        
        if(hasBeenPlayer == false){
            transform.position += Vector3.up *5;
            hasBeenPlayer= true;
            
        }
        

    }


 
}
