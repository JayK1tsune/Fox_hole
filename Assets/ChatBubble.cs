using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatBubble : MonoBehaviour
{ 
    private SpriteRenderer _background;
    private Text _text;
    private TextMeshPro textMeshPro;

    private void Awake() {
        _background = transform.Find("Chat").GetComponent<SpriteRenderer>();
        _text = transform.Find("Text").GetComponent<Text>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Setup(string text){
        textMeshPro.SetText(text);
    }
}
