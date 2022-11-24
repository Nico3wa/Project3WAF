using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "So/target")]
public class targetSo : ScriptableObject
{
     [SerializeField] GameObject targetGameObject;
    [SerializeField] Management _man;
    [SerializeField] ImEnemy _enemy;
    public GameObject TargetGameObject { get => targetGameObject; set => targetGameObject = value; }
    public Management Man { get => _man; set => _man = value; }
    public ImEnemy Enemy { get => _enemy; set => _enemy = value; }
}
