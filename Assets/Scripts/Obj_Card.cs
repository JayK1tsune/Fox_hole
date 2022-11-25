using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Obj_Card : ScriptableObject{

public new string name;
public string description;
 public Sprite artWork;

 public int move;
 public bool attack_while_move;
 public bool can_teleport;

}


