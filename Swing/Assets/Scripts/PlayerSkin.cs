using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player", menuName = "Skins/player")]
[Serializable]
public class PlayerSkin : ScriptableObject
{
    public GameObject skin;
    public float price;
}
