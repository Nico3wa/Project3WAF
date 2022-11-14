using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat: MonoBehaviour
{
    [SerializeField] CharacterSo _Stat;
    int _currentLife;
    [SerializeField] Animator _animator;
    [SerializeField] Animator _2nd;
    int maxKi;
    int currentKi;
    [SerializeField] Mouvement _mouv;

    public int CurrentKi { get => currentKi; set => currentKi = value; }

    // Start is called before the first frame update
    void Start()
    {
        _currentLife = _Stat.MaxHp;
        maxKi = _Stat.Maxki;
        currentKi = _Stat.Ki;
    }

    private void Update()
    {
        if (currentKi > maxKi)
        {
            currentKi = maxKi;
        }
    }

    public void Damage(int amount)
    {
        _currentLife = _currentLife - amount;
        Debug.Log(_currentLife);
        if (_animator != null)
        {
            _animator.SetTrigger("Hit");
        }
        else
        {
            _2nd.SetTrigger("Hit");
        }


        if (_currentLife <= 0)
        {
            Debug.Log(_currentLife);
            if (_animator != null)
            {
                _animator.SetTrigger("Death");
            }
            else
            {
                _2nd.SetTrigger("Death");
            }
        }
    }
   
}


