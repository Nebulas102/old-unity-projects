using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="weapon", menuName ="Skins/Weapon")]
[Serializable]
public class WeaponSkin : ScriptableObject
{
    public GameObject skin;
    public float price;
}
