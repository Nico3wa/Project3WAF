using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat: MonoBehaviour
{
    [SerializeField] CharacterSo _Stat;
    int _maxLife;
    int _currentLife;
    [SerializeField] Animator _animator;
    [SerializeField] Animator _2nd;
    int maxKi;
    int currentKi;
    [SerializeField] Mouvement _mouv;
    int gainki;
    #region string
    string _hp;
    string _ki;
    #endregion
    public int CurrentKi { get => currentKi; set => currentKi = value; }
    public int MaxKi { get => maxKi; set => maxKi = value; }
    public int Gainki { get => gainki; set => gainki = value; }
    public int CurrentLife { get => _currentLife; set => _currentLife = value; }
    public int MaxLife { get => _maxLife; set => _maxLife = value; }
    public string Hp { get => _hp;}
    public string Ki { get => _ki;}

    // Start is called before the first frame update
    void Start()
    {
        gainki = _Stat.Addki;
        _currentLife = _Stat.MaxHp;
        maxKi = _Stat.Maxki; 
        currentKi = _Stat.Ki;
        _maxLife = _currentLife;
        _hp = _currentLife.ToString();
        _ki = currentKi.ToString();
    }

    private void Update()
    {
        if (currentKi > maxKi)
        {
            currentKi = maxKi;
        }
         _hp = _currentLife.ToString();
        _ki = currentKi.ToString();
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


