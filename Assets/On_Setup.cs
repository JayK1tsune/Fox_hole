using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Art used for shop Ui is from https://i.redd.it/z5t6m4jyp1n71.png - with permission from artist as long as this game is not sold //

public class On_Setup : MonoBehaviour
{
    [SerializeField] GameObject card_ui;
    Exit_Spawn xs;
 
    void Start()
    {
        card_ui.gameObject.SetActive(true);
    }

    public void NewLevel(){
        xs.Shop_ui.gameObject.SetActive(false);
        card_ui.gameObject.SetActive(true);

    }

}
