using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class health : MonoBehaviour
{
    [SerializeField] UnityEvent _onDamage;
    [SerializeField] Animator _animator;
    int currenthp;

    [SerializeField] HealthSo _Maxhp;

    void Start()
    {
        currenthp = _Maxhp.Maxhp;
    }

    // Update is called once per frame
    public void Damage(int amount)
    {
        currenthp = currenthp - amount;
        Debug.Log(currenthp);
        if (_animator != null)
        {
            _animator.SetTrigger("Hit");
        }


        if (currenthp <= 0)
        {
            Debug.Log(currenthp);
            if (_animator != null)
            {
                _animator.SetTrigger("Death");
            }
        }
    }
}
