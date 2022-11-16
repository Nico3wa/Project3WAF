using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "So/player/Character")]
public class CharacterSo : ScriptableObject
{
    [SerializeField] int _ki;
    [SerializeField] int _Maxki;
    [SerializeField] int _MaxHp;
    [SerializeField] int _speed;
    [SerializeField] int _atkSPeed;
    [SerializeField] string _name;
    [SerializeField] int addki;

    public int Ki { get => _ki; set => _ki = value; }
    public int Speed { get => _speed; set => _speed = value; }
    public int MaxHp { get => _MaxHp; set => _MaxHp = value; }
    public string Name { get => _name; set => _name = value; }
    public int Maxki { get => _Maxki; set => _Maxki = value; }
    public int AtkSPeed { get => _atkSPeed; set => _atkSPeed = value; }
    public int Addki { get => addki; set => addki = value; }
}
