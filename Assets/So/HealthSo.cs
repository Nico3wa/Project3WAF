using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "So/Health")]

public class HealthSo : ScriptableObject
{
    [SerializeField] int _Maxhp;

    public int Maxhp { get => _Maxhp; }
}
