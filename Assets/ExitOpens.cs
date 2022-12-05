using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOpens : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject gm;
  
    private void Start() {
        gameManager = gm.GetComponent<GameManager>();
        StartCoroutine(gameManager.OpenExit());
    }

}

