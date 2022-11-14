using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "So/Enemy")]
public class EnemySo : ScriptableObject
{
    [SerializeField] float _Maxhp;
    [SerializeField] int _attack;
    [SerializeField] float speed;
    [SerializeField] float _AttackCD;
    [SerializeField] string _name;

    public string Name { get => _name; }
    public float AttackCD { get => _AttackCD; }
    public float Speed { get => speed; }
    public float Maxhp { get => _Maxhp;}
    public int Attack { get => _attack;  }
}
