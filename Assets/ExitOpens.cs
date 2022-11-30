using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOpens : MonoBehaviour
{
    [SerializeField] GameObject _exit;
    [SerializeField] int _exitTimer;
    IEnumerator Start(){
    yield return new WaitForSeconds(_exitTimer);
    _exit.gameObject.SetActive(true);

    }
}

