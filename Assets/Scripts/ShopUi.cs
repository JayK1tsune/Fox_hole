using UnityEngine;


public class ShopUi : MonoBehaviour
{
    deck_of_cards deckOfCards;
    CoinCollection coinCollection;
    [SerializeField] GameObject doc;
    [SerializeField] GameObject _coins;
    [SerializeField] GameObject _errorNoCoins;

    private void Awake() {
        deckOfCards = doc.GetComponent<deck_of_cards>();
        coinCollection = _coins.GetComponent<CoinCollection>();
    }
    private void OnDisable() {
        _errorNoCoins.SetActive(false);
    }

    public void AddCard(int categoryNum){
        if(coinCollection.coins >= 2){
            deckOfCards.deck.Add( deckOfCards.Categories[categoryNum].cardList[Random.Range(0, deckOfCards.Categories[categoryNum].cardList.Length)]);
            coinCollection.coins--;
            coinCollection.coins--;
            coinCollection.coinsText.text = ""+coinCollection.coins;
            coinCollection.coinsShop.text = ""+coinCollection.coins;
        }
        else{
            
            _errorNoCoins.SetActive(true);
        }
        

    }

    public void RemoveCard(int categoryNum){
        if(coinCollection.coins >= 5){
            
            for (int i = 0; i < 5; i++)
            {
                coinCollection.coins--;
            }
            coinCollection.coinsText.text = ""+coinCollection.coins;
            coinCollection.coinsShop.text = ""+coinCollection.coins;
            deckOfCards.deck.Remove(deckOfCards.Categories[categoryNum].cardList[Random.Range(0, deckOfCards.Categories[categoryNum].cardList.Length)]);
        }
        else{
            _errorNoCoins.SetActive(true);
        }
       
    }
    

    
}
