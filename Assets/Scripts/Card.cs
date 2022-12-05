using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    private BoxCollider2D boxCollider2D;
    deck_of_cards deckOfCards;
    GameManager gameManager;
    Player_Controller playerController;
    [SerializeField] GameObject gameM;
    [SerializeField] GameObject playercontroller;
    [SerializeField] public SpriteRenderer _player;
    private void Awake() {
        Instance = this;
        _player = _player.GetComponent<SpriteRenderer>();
        _orignalColour = _player.GetComponent<SpriteRenderer>();
        gameManager = gameM.GetComponent<GameManager>();
        deckOfCards = gameM.GetComponent<deck_of_cards>();
        playerController = playercontroller.GetComponent<Player_Controller>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
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
            boxCollider2D.isTrigger = false;
            if (playerController.moveSpeed <= 1){
            playerController.moveSpeed = playerController.moveSpeed+0.1f;
            SpeedDelay(1f,0.1f);
            }
            
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
           // Invoke("MoveToDiscardPile",2f);
            break;
        case 2:
            print ("movment 2");
            boxCollider2D.isTrigger = false;
            if (playerController.moveSpeed <= 1){
            playerController.moveSpeed = playerController.moveSpeed+0.1f;
            SpeedDelay(2f,0.1f);
            }
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
           // Invoke("MoveToDiscardPile",3f);
            break;
        case 3:
            print("Movment 3");
            boxCollider2D.isTrigger = false;
            if (playerController.moveSpeed <= 1){
            playerController.moveSpeed = playerController.moveSpeed+0.1f;
            SpeedDelay(3f,0.1f);
            }
          
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
           // Invoke("MoveToDiscardPile",4f);
            break;
        case 4:
            print ("movement 4");
            boxCollider2D.isTrigger = false;
            if (playerController.moveSpeed <= 1){
            playerController.moveSpeed = playerController.moveSpeed+0.1f;
            SpeedDelay(4f,0.1f);
            }
            
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            Invoke("MoveToDiscardPile",5f);
            break;
        case 5:
            print("movement 5");
            boxCollider2D.isTrigger = false;
            if (playerController.moveSpeed <= 1){
            playerController.moveSpeed = playerController.moveSpeed+0.1f;
            SpeedDelay(5f,0.1f);
            }
            
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            //Invoke("MoveToDiscardPile",6f);
            break;
        case 6:
            print("movement 6");
            boxCollider2D.isTrigger = false;
            if (playerController.moveSpeed <= 1){
            playerController.moveSpeed = playerController.moveSpeed+0.1f;
            SpeedDelay(6f,0.1f);
            }
            
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            //Invoke("MoveToDiscardPile",7f);
            break;
        default:
            print("movement 0");
            boxCollider2D.isTrigger = false;
            if (playerController.moveSpeed <= 1){
            AttackDelay(1f,_movmement);
            }
            _hasBeenPlayed =true;
            deckOfCards.availableCardSlots[_handIndex] = true;
            //Invoke("MoveToDiscardPile",6f);
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





    public void SpeedDelay(float delayTime, float speed){
        StartCoroutine(DelayAction(delayTime,speed));
    }
    IEnumerator DelayAction(float delayTime, float speed){
        
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
        deckOfCards.discardPile.Add(this);
        playerController.moveSpeed = playerController.moveSpeed - speed;
        if(_canAttack){
            playerController._ghostCanHit=false;
            _player.color = new Color(1,1,1,1);
            gameManager.canAttack = false;
        }
        Debug.Log(playerController.moveSpeed);
        yield return null;
       
    }
    public void AttackDelay(float delay, int _movment){
        StartCoroutine(DelayAttack(delay,_movmement));
    }
    IEnumerator DelayAttack(float delay, int _movmement){
        yield return new WaitForSeconds(delay);
        gameManager.canAttack = false;
        _player.color = new Color(1,1,1,1);
        yield return null;
    }
    void ReturnSpeed(){
        playerController.moveSpeed = playerController.moveSpeed - 0.1f;
    }

}
