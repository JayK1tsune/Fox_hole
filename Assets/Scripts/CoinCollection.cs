using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    public int coins = 0;
    [SerializeField] public Text coinsText;
    [SerializeField] public Text coinsShop;
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
            Destroy(collider2D.gameObject);
            coins++;
            coinsText.text = ""+coins;
            coinsShop.text = ""+coins;
        }
    }

}
