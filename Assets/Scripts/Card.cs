using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class Card : MonoBehaviour, IPointerClickHandler
{
    public List<Card> deck = new List<Card>();
    public static Card Instance{get; private set;}
    public int movmement = -1;
    public bool canAttack;
    public bool canTeleport;
    public int handIndex;
    private deck_of_cards doc;
    public bool hasBeenPlayed;
    deck_of_cards deckOfCards;
    GameManager gameManager;
    Player_Controller playerController;
    [SerializeField] GameObject gameM;
    [SerializeField] GameObject playercontroller;
    private void Awake() {
        Instance = this;
        
        gameManager = gameM.GetComponent<GameManager>();
        deckOfCards = gameM.GetComponent<deck_of_cards>();
        playerController = playercontroller.GetComponent<Player_Controller>();
      
    }

    private void Start(){
        doc = FindObjectOfType<deck_of_cards>();
    }
    public void OnPointerClick (PointerEventData eventData)
    {
        switch(movmement)
        {
        case 1:
            print ("movment 1");
            playerController.MaxMovment = 1f;
            gameObject.SetActive(false);
            break;
        case 2:
            print ("movment 2");
            playerController.MaxMovment = 2f;
            gameObject.SetActive(false);
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

        switch(canTeleport)
        {
        case true:
            print ("Can TP");
            break;
        case false:
            print("Can not TP");
            break;
        }
 
    }


 


 
}
