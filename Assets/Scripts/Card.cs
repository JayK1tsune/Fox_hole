using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public List<Card> deck = new List<Card>();
    public static Card Instance{get; private set;}
    public int _movmement;
    public bool _canAttack;
    public bool _canTeleport;
    private float _currentMovement;
    public int _handIndex;
    private deck_of_cards doc;
    public bool _hasBeenPlayed;
    private SpriteRenderer _orignalColour;
    deck_of_cards deckOfCards;
    GameManager gameManager;
    Player_Controller playerController;
    [SerializeField] GameObject gameM;
    [SerializeField] GameObject playercontroller;
    [SerializeField] SpriteRenderer _player;
    private void Awake() {
        Instance = this;
        _player = _player.GetComponent<SpriteRenderer>();
        _orignalColour = _player.GetComponent<SpriteRenderer>();
        gameManager = gameM.GetComponent<GameManager>();
        deckOfCards = gameM.GetComponent<deck_of_cards>();
        playerController = playercontroller.GetComponent<Player_Controller>();
    }
    private void Start(){
        doc = FindObjectOfType<deck_of_cards>();
    }
    private void Update() {
        gameManager._playCurrentSpeed = playerController.moveSpeed;
    }
    // enum Test : uint
    // {
    //     OptionOne = 1,
    //     OptionTwo,
    //     OptionThree,
    //      None
    // }
    
    //Switch Statements for Card clicks.
    public void OnPointerClick (PointerEventData eventData)
    {
        switch(_movmement)
        {
        case 1:
            print ("movment 1");
            
            Debug.Log(playerController.moveSpeed);
            if (playerController.moveSpeed <= 1){
            playerController.moveSpeed = playerController.moveSpeed+0.1f;
            Debug.Log(playerController.moveSpeed);
            SpeedDelay(5f);
            }
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            
            Debug.Log(playerController.moveSpeed);
            Invoke("MoveToDiscardPile",1f);
            break;
        case 2:
            print ("movment 2");
            playerController.moveSpeed = playerController.moveSpeed+0.2f;
            
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            Invoke("MoveToDiscardPile",1f);
            break;
        case 3:
            print("Movment 3");
            
            playerController.MaxMovment = 1f;
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            Invoke("MoveToDiscardPile",1f);
            break;
        case 4:
            print ("movement 4");
            playerController.MaxMovment = 1f;
            
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            Invoke("MoveToDiscardPile",1f);
            break;
        case 5:
            print("movement 5");
            playerController.MaxMovment = 1f;
            
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            Invoke("MoveToDiscardPile",1f);
            break;
        case 6:
            print("movement 6");
            playerController.MaxMovment = 1f;
            
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            Invoke("MoveToDiscardPile",1f);
            break;
        default:
            print("movement 0");
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            Invoke("MoveToDiscardPile",1f);
            break;

        }
        switch(_canAttack)
        {
        case true:
            playerController._ghostCanHit=true;
            _player.color = new Color(1,0,0,1);
            gameManager.canAttack = true;
            break;
        case false:
            playerController._ghostCanHit=false;
            _player.color = new Color(1,1,1,1);
            gameManager.canAttack = false;
            break;
        }

        switch(_canTeleport)
        {
        case true:
            print ("Can TP");
            break;
        case false:
            print("Can not TP");
            break;
        }
 
    }





    public void SpeedDelay(float delayTime){
        StartCoroutine(DelayAction(delayTime));
    }
    IEnumerator DelayAction(float delayTime){
        yield return new WaitForSeconds(delayTime);
        playerController.moveSpeed = playerController.moveSpeed - 0.1f;
        

    }
    void ReturnSpeed(){
        playerController.moveSpeed = playerController.moveSpeed - 0.1f;
    }
    void MoveToDiscardPile(){
        deckOfCards.discardPile.Add(this);
        gameObject.SetActive(false);
    }
}
