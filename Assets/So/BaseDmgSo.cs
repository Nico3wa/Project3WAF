using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "So/player/damage")]

public class BaseDmgSo : ScriptableObject
{
    [SerializeField] int dmg;

    public int Dmg { get => dmg; set => dmg = value;}
}
