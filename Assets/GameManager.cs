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
    public GameObject Grid;
    public List<CoinCollection> _coins = new List<CoinCollection>();
    public List<GhostAI> _spawnLocations = new List<GhostAI>();
    public GameObject _ghostPrefab;
    CoinCollection coinCollection;
    CoinSpawner coinSpawner;
   
    Exit_Spawn exitspawn;
    deck_of_cards deck_Of_Cards;
    [SerializeField] GameObject exitS;
    [SerializeField] GameObject _coinSpawner;
    [SerializeField] GameObject _coinCollection;
    [SerializeField] GameObject docs;

    private void Awake() {
        exitspawn = exitS.GetComponent<Exit_Spawn>();
        coinSpawner = _coinSpawner.GetComponent<CoinSpawner>();
        coinCollection = _coinCollection.GetComponent<CoinCollection>();
        deck_Of_Cards = docs.GetComponent<deck_of_cards>();

    }

    
    public void NewLevel(){
        player.gameObject.SetActive(true);
        Grid.gameObject.SetActive(true);
        Card_ui.gameObject.SetActive(true);
        Shop_ui.gameObject.SetActive(false);
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        if(player){
            Debug.Log("I'm teh Fox");
        }
    }




    


}
