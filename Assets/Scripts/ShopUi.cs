using UnityEngine;


public class ShopUi : MonoBehaviour
{
    deck_of_cards deckOfCards;
    CoinCollection coinCollection;
    [SerializeField] GameObject doc;
    [SerializeField] GameObject _coins;
    [SerializeField] GameObject _errorNoCoins;
    //atempt to change volume of main music as i enter the shop
     //MusicManager musicManager;
 


    private void Awake() {
        deckOfCards = doc.GetComponent<deck_of_cards>();
        coinCollection = _coins.GetComponent<CoinCollection>();
        //musicManager._volume.Pause(); 
        
    }

       

    private void OnDisable() {
        _errorNoCoins.SetActive(false);
        //musicManager._volume.Play
        
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
