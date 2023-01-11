using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAtk : MonoBehaviour
{
    [SerializeField] KnightMouv _Action;
    [SerializeField] List<PlayerStat> _savedCharacter;
    Coroutine _attackRoutine;
    float cd;
    public List<PlayerStat> SavedCharacter { get => _savedCharacter; }

    private void Update()
    {
        cd = _Action.CD;
    }
   private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.attachedRigidbody == null) return;
        var h = col.attachedRigidbody.GetComponent<PlayerStat>();
        if (h != null && _Action.CanAttack == true)
        {
            if (_savedCharacter.Contains(h))
            {
                _Action.CanAttack = false;
                _Action.MyAnimator.SetTrigger("isAttacking");
                    _attackRoutine = StartCoroutine(AttackRoutine());
        
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
        if (h != null && _Action.CanAttack == true)
        {
            if (_savedCharacter.Contains(h))
            {
                _Action.CanAttack = false;
                _Action.MyAnimator.SetTrigger("isAttacking");
                    _attackRoutine = StartCoroutine(AttackRoutine());
         
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
   
        yield return new WaitForSeconds(cd);
        _Action.CanAttack = true;
    }
}
