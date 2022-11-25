using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        Spawn.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject == player){
            Debug.Log("This works now?");
        }
        
    }
}
   

       

