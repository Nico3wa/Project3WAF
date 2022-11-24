using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;

    public Rigidbody2D Rb { get => _rb; set => _rb = value; }

}
