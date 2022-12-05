using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[Serializable]
public class cardTypes
{
    public string Name;
    public Card[] cardList;
}

public class deck_of_cards : MonoBehaviour
{
   public List<Card> deck = new List<Card>();
   public List<Card> discardPile = new List<Card>();
   public Transform[] cardSlots;
   public bool[] availableCardSlots;
   public Text deckSizeText;
   public Text discardSizeText;
   public Text shuffleText;
   public int shuffleNumber;

public cardTypes[] Categories;

private void Start() {
    shuffleNumber = 1;
}
   public void DrawCard(){
        if(deck.Count >= 1){
            Card randCard = deck[UnityEngine.Random.Range(0,deck.Count)];

            for(int i = 0; i < availableCardSlots.Length; i++){
                if(availableCardSlots[i] == true){
                    randCard.gameObject.SetActive(true);
                    randCard._handIndex = i;
                    randCard.transform.position = cardSlots[i].position;
                    randCard._hasBeenPlayed =false;
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                    
                }
            }
        }
   }

   public void Shuffle(){
    if (discardPile.Count >= 1 && shuffleNumber >= 1){
        foreach (Card card in discardPile)
        {
            deck.Add(card);
        }
        discardPile.Clear();
        shuffleNumber--;
    }
   }

   public void Update(){
    deckSizeText.text = deck.Count.ToString();
    discardSizeText.text = discardPile.Count.ToString();
    shuffleText.text = shuffleNumber.ToString(shuffleNumber+ "\n Shuffles Left");
   }
}
