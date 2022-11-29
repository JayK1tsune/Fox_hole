using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IPointerDownHandler
{

    public GameObject Spawn;
    public GameObject player;
    public GameObject Shop_ui;
    public GameObject Card_ui;
    [SerializeField] GameObject pause_ui;
    public GameObject Start_Spawn;
    public GameObject Grid;
   
    Exit_Spawn exitspawn;
    [SerializeField] GameObject exitS;

    private void Awake() {
        exitspawn = exitS.GetComponent<Exit_Spawn>();
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
