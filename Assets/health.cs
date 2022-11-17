using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    [SerializeField] UnityEvent _onDamage;
    [SerializeField] Animator _animator;
    int currenthp;
    int maxHp;
    [SerializeField] GameObject _Slider;


    [SerializeField] HealthSo _Maxhp;

    public int Currenthp { get => currenthp; set => currenthp = value; }
    public int MaxHp { get => maxHp; set => maxHp = value; }

    void Start()
    {
        maxHp = _Maxhp.Maxhp;
        currenthp = _Maxhp.Maxhp;
    }
    private void Update()
    {
        if (currenthp != maxHp)
        {
            _Slider.SetActive(true);
        }
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
