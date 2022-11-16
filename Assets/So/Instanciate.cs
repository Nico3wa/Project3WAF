using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "So/Special")]
public class Instanciate : ScriptableObject
{

    [SerializeField] GameObject _instance;
    [SerializeField] int _value;
    [SerializeField] int _life;
    [SerializeField] int _dmg;
    [SerializeField] int _consomation;

    public GameObject Instance { get => _instance;}
    public int Value { get => _value;}
    public int Life { get => _life; set => _life = value; }
    public int Dmg { get => _dmg; set => _dmg = value; }
    public int Consomation { get => _consomation; set => _consomation = value; }
}
