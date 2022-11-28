using UnityEngine;


public class ShopUi : MonoBehaviour
{
    deck_of_cards deckOfCards;
    [SerializeField] GameObject doc;

    private void Awake() {
        deckOfCards = doc.GetComponent<deck_of_cards>();
    }

    public void AddCard(int categoryNum){
 

        deckOfCards.deck.Add( deckOfCards.Categories[categoryNum].cardList[Random.Range(0, deckOfCards.Categories[categoryNum].cardList.Length)]);

    }

    public void RemoveCard(int categoryNum){
        deckOfCards.deck.Remove(deckOfCards.Categories[categoryNum].cardList[Random.Range(0, deckOfCards.Categories[categoryNum].cardList.Length)]);
    }
    

    
}
