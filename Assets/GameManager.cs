using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IPointerDownHandler
{

    public GameObject _spawn;
    public GameObject player;
    public GameObject Shop_ui;
    public GameObject Card_ui;
    [SerializeField] GameObject pause_ui;
    public GameObject Start_Spawn;
    private bool _isDead;
    private bool _isInShop;
    public int _ghostDeathCount;
    public bool canAttack;
    public float _playCurrentSpeed;
    public GameObject Grid;
    public List<CoinCollection> _coins = new List<CoinCollection>();
    public List<GhostAI> _spawnLocations = new List<GhostAI>();
    public GameObject _ghostPrefab;
    CoinCollection coinCollection;
    CoinSpawner coinSpawner;
    PauseMenu pauseMenu;
    
   
    Exit_Spawn exitspawn;
    deck_of_cards deck_Of_Cards;
    GhostAI ghostAI;
    Card card;
    [SerializeField] GameObject GAI;
    [SerializeField] GameObject exitS;
    [SerializeField] GameObject _coinSpawner;
    [SerializeField] GameObject _coinCollection;
    [SerializeField] GameObject docs;
    [SerializeField] GameObject pm;
    [SerializeField] GameObject _card;

    private void Awake() {
        ghostAI = GAI.GetComponent<GhostAI>();
        exitspawn = exitS.GetComponent<Exit_Spawn>();
        coinSpawner = _coinSpawner.GetComponent<CoinSpawner>();
        coinCollection = _coinCollection.GetComponent<CoinCollection>();
        deck_Of_Cards = docs.GetComponent<deck_of_cards>();
        pauseMenu = pm.GetComponent<PauseMenu>();
        card = _card.GetComponent<Card>();

    }
    private void Start() {
        _ghostDeathCount = 4;
        canAttack = false;
        
    }

    
    public void NewLevel(){
        player.gameObject.SetActive(true);
        Grid.gameObject.SetActive(true);
        Card_ui.gameObject.SetActive(true);
        Shop_ui.gameObject.SetActive(false);
        ghostAI.gameObject.SetActive(true);
        _isInShop = false;
    }
    private void Update() {
        if (_ghostDeathCount <= 0)
        {
            _isDead = true;
            WinScreen(_isDead);
        }
        //if(_isInShop){
        //    Invoke("MoveToDiscardPile",0f);
        //}

        
        
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        if(player){
            Debug.Log("I'm teh Fox");
        }
    }
    public void WinScreen(bool _gameover){
        
            SceneManager.LoadScene("WinScreen");
    }
    void OnEsc(){
    if(pauseMenu.GameIsPaused == false){
            pauseMenu.Pause();           
        }
        else{
            pauseMenu.Resume();
        }
        Debug.Log("I pressed Esc");
    }

    public void ShopEnter(){
        _isInShop = true;
        deck_Of_Cards.shuffleNumber++;
        player.gameObject.transform.position = Start_Spawn.gameObject.transform.position;
        player.gameObject.transform.rotation = Start_Spawn.gameObject.transform.rotation;
        player.gameObject.SetActive(false);
        Grid.gameObject.SetActive(false);
        Card_ui.gameObject.SetActive(false);
        Shop_ui.gameObject.SetActive(true);
        deck_Of_Cards.shuffleText.text = deck_Of_Cards.shuffleNumber.ToString(deck_Of_Cards.shuffleNumber+ "\n Shuffles Left");
   


        if(CompareTag("Ghost")){
            ghostAI.gameObject.SetActive(false);
            ghostAI.gameObject.transform.position = ghostAI._escape.gameObject.transform.position;
            ghostAI.gameObject.transform.rotation = ghostAI._escape.gameObject.transform.rotation;
        }
        

        //deck_Of_Cards.cardSlots.SetValue(deck_Of_Cards.cardSlots,0);

    }
    void MoveToDiscardPile(){
        deck_Of_Cards.discardPile.Add(Card.Instance);
        gameObject.SetActive(false);
    }





    


}
