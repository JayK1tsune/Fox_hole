using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject objectToSpawn;

  public void SpawnCoins(){

    Instantiate(objectToSpawn,transform.position, transform.rotation);
  }
}
