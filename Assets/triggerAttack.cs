using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAttack : MonoBehaviour
{
    [SerializeField] GameObject _Target;
    [SerializeField] EnemyMouv _Action;

    GameObject _player;
    public GameObject Player { get => _player; }

    Coroutine _attackRoutine;
    public Coroutine AttackRoutine1 { get => _attackRoutine; set => _attackRoutine = value; }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject == _Target)
        {
            _player = null;
            //  _Action.State1 = State.IDLE;
        }
    }

    void OnTriggerEnter2D(Collider2D c) => CheckCollision(c);
    void OnTriggerStay2D(Collider2D c) => CheckCollision(c);

   public void CheckCollision(Collider2D c)
    {

        if (c.gameObject == _Target && _Action.CanAttack == true && _attackRoutine==null)
        {
            _player = c.gameObject;
            _Action.MyAnimator.SetTrigger("isAttacking");
            _attackRoutine = StartCoroutine(AttackRoutine());

            //Component.GetName

        }
        else
        {
            return;
        }
    }

    IEnumerator AttackRoutine()
    {
        _Action.CanAttack = false;
        yield return new WaitForSeconds(_Action.CD);
        _Action.CanAttack = true;
        _attackRoutine = null;
    }


 /*   public void CheckCollision(Collider2D c)
    {
        if (c.gameObject == _Target)
        {
            checkUpdate = StartCoroutine(CheckRoutine());
            IEnumerator CheckRoutine()
            {
                while (true)
                {
                    if (_Action.CanAttack == true && _attackRoutine == null)
                    {
                        _player = c.gameObject;
                        _Action.MyAnimator.SetTrigger("isAttacking");
                        _attackRoutine = StartCoroutine(AttackRoutine());
                    }
                    yield return null;
                }
            }
        }
*/
  //  }
}
