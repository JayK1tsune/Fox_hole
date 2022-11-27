using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    public GameObject Spawn;
    public GameObject player;
    public GameObject Shop_ui;
    public GameObject Card_ui;
    public GameObject Start_Spawn;
    public GameObject Grid;
   
    Exit_Spawn exitspawn;
    [SerializeField] GameObject exitS;

    private void Awake() {
        exitspawn = exitS.GetComponent<Exit_Spawn>();
    }

    private void Update() {
        
    }
    
    public void NewLevel(){
        player.gameObject.SetActive(true);
        Grid.gameObject.SetActive(true);
        Card_ui.gameObject.SetActive(true);
        Shop_ui.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(player){
            Debug.Log("I'm teh Fox");
        }
        
  
   
    }

}
