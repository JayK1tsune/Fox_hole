using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class Card : MonoBehaviour, IPointerClickHandler
{
    public static Card Instance{get; private set;}
    public int movmement = -1;
    public bool canAttack;
    public bool canTeleport;
    public int handIndex;
    private deck_of_cards doc;
    public bool hasBeenPlayed;

    private void Awake() {
        Instance = this;
       
    }

    private void Start(){
        doc = FindObjectOfType<deck_of_cards>();
    }
    public void OnPointerClick (PointerEventData eventData)
    {
        switch(movmement)
        {
        case 1:
            print ("movment 2");
            break;
        case 2:
            print ("movment 2");
            break;
        case 3:
            print("Movment 3");
            break;
        case 4:
            print ("movement 4");
            break;
        case 5:
            print("movement 5");
            break;
        case 6:
            print("movement 6");
            break;

        }
        switch(canAttack)
        {
        case true:
            print ("Can attack");
            break;
        case false:
            print("Can not attack");
            break;
        }
 
    }


 


 
}
