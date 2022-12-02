using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
  CoinCollection coinCollection;
  [SerializeField] GameObject _coinCollection;
  [SerializeField] GameObject _SpawnCoins;

  private void Awake() {
    coinCollection = _coinCollection.GetComponent<CoinCollection>();

  }
  private void Update() {
    if (coinCollection.coins >= 1)
    {
      SpawnCoins(_SpawnCoins);
    }
  }

  


  void SpawnCoins(GameObject _SpawnCoins){
  StartCoroutine(Spawner(_SpawnCoins));

  }
  IEnumerator Spawner(GameObject _SpawnCoins)
  {
    
    yield return new WaitForSeconds(2.0f);
    Instantiate(_SpawnCoins, new Vector2(2.0f, 0), Quaternion.identity);

  }

}
