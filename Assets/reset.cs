using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    [SerializeField] EnemyMouv mouv;
    [SerializeField] GameObject _target;
    [SerializeField] GameObject _correspondance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _target = collision.gameObject;
        if (_target.gameObject == _correspondance)
        {
            mouv.State1 = State.IDLE;


        }
    }

}
