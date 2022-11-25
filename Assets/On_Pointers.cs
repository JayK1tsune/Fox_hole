using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class On_Pointers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    Card card;

    
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        print($"enter on {this.name}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
          print($"Exit on {this.name}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left){
 
        }
    }
}
