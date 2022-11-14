using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvProx : MonoBehaviour
{
    [SerializeField] GameObject _bankai;
    [SerializeField] GameObject _base;
    [SerializeField] GameObject _me;

    [SerializeField] Mouvement _mouv;
   public  bool canMove;
    bool _canMoveAtk;

    public bool CanMoveAtk { get => _canMoveAtk; set => _canMoveAtk = value; }

    private void Start()
    {
        canMove = true;
      
    }
    private void Update()
    {
       if (_mouv.Attacking && canMove)
        {

            OnMove();
        }
   /*    if (_canMoveAtk)
        {
            OnMoveAtk();
        }*/
    }

/*    void OnMoveAtk()
    {
        if (_canMoveAtk)
        {
            _me.transform.position = _base.transform.position;
            _canMoveAtk = false;
            StartCoroutine(MoveAttackRoutine());
        }
    }*/

    void OnMove()
    {
        if (canMove)
        {
           _me.transform.position = _base.transform.position;
            canMove = false;
            StartCoroutine(AttackRoutine());
        }

    }
    IEnumerator AttackRoutine()
    {

        yield return new WaitForSeconds(0.3f);
        canMove = true;
        StopCoroutine(AttackRoutine());
}
   /* IEnumerator MoveAttackRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _canMoveAtk = true;
        StopCoroutine(AttackRoutine());
    }
    */

    }
