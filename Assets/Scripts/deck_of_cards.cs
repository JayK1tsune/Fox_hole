using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deck_of_cards : MonoBehaviour
{
   public List<Card> deck = new List<Card>();
   public Transform[] cardSlots;
   public bool[] availableCardSlots;
   public Text deckSizeText;


   public void DrawCard(){
        if(deck.Count >= 1){
            Card randCard = deck[Random.Range(0,deck.Count)];

            for(int i = 0; i < availableCardSlots.Length; i++){
                if(availableCardSlots[i] == true){
                    randCard.gameObject.SetActive(true);
                    // randCard.handIndex = i;
                    randCard.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                    
                }
            }
        }
   }

   public void Update(){
    deckSizeText.text = deck.Count.ToString();
   }
}
