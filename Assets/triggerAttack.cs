using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAttack : MonoBehaviour
{
    [SerializeField] EnemyMouv _Action;
    [SerializeField] training _train;
    [SerializeField] List<PlayerStat> _savedCharacter;
    Coroutine _attackRoutine;
    public Coroutine AttackRoutine1 { get => _attackRoutine; set => _attackRoutine = value; }
    public List<PlayerStat> SavedCharacter { get => _savedCharacter; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.attachedRigidbody == null) return;
        var h = col.attachedRigidbody.GetComponent<PlayerStat>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {
                if (_Action != null)
                {
                    _Action.MyAnimator.SetTrigger("isAttacking");
                    _attackRoutine = StartCoroutine(AttackRoutine());
                }
               
                {
                    _train.MyAnimator.SetTrigger("isAttacking");
                    _attackRoutine = StartCoroutine(AttackRoutine());

                }
            }
            else
            {
                _savedCharacter.Add(h);
            }

        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.attachedRigidbody == null) return;
        var h = col.attachedRigidbody.GetComponent<PlayerStat>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {
                if (_Action != null)
                {
                    _Action.MyAnimator.SetTrigger("isAttacking");
                    _attackRoutine = StartCoroutine(AttackRoutine());

                }
               
                {
                    _train.MyAnimator.SetTrigger("isAttacking");
                    _attackRoutine = StartCoroutine(AttackRoutine());

                }
            }
            else
            {
                _savedCharacter.Add(h);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.attachedRigidbody == null) return;
        var h = col.attachedRigidbody.GetComponent<PlayerStat>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {
                _savedCharacter.Remove(h);
            }
        }
    }

    IEnumerator AttackRoutine()
    {
        if (_Action != null)
        {
            _Action.CanAttack = false;
            yield return new WaitForSeconds(_Action.CD);
        _Action.CanAttack = true;
        _attackRoutine = null;
         
        }
      else
        {
            _train.CanAttack = false;
            yield return new WaitForSeconds(_train.CD);
            _train.CanAttack = true;
            _attackRoutine = null;
        }
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
