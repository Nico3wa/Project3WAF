using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
public class Special1 : MonoBehaviour
{

    [SerializeField] InputActionReference _special;

    [SerializeField] GameObject _object;
    [SerializeField] Transform _spawn;
    [SerializeField] Instanciate Instanciate;
    [SerializeField] Mouvement _action;
    [SerializeField] Animator _animator;
    int _cosomation;
 
    [SerializeField] PlayableDirector GetsugaTensho;
    [SerializeField] PlayableDirector _air;
    [SerializeField] PlayerStat _stat;
    [SerializeField] atk _atk;
    bool ready;
    public Transform Spawn { get => _spawn; set => _spawn = value; }

    private void Start()
    {
        ready = false;
        _cosomation = Instanciate.Consomation;
        _special.action.started += SpecialON;
        _object = Instanciate.Instance;
    }
    private void Update()
    {
        if (_stat.CurrentKi >= _cosomation && _action.Attacking == false
            || _stat.CurrentKi >= _cosomation && _action.JumpAttack == false)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }
    }
    private void SpecialON(InputAction.CallbackContext obj)
    {
        if (ready) 
        { 
            if (_action._isGrounded && _action.Isdash == false && !_animator.GetBool("Mouv") && !_animator.GetBool("inDash"))
            {
                _action.Animator.SetBool("OnAttack",false);
                _action.Animator.SetBool("AirAtk", false);
                GetsugaTensho.Play();
                _stat.CurrentKi -= _cosomation;
            }
            else if (!_animator.GetBool("doubleSaut") && _animator.GetBool("Landing") && !_animator.GetBool("inDash") && !_animator.GetBool("Mouv"))
            {
                _action.Animator.SetBool("OnAttack", false);
                _action.Animator.SetBool("AirAtk", false);
                _air.Play();
                _stat.CurrentKi -= _cosomation;
            }          
        }
        else
        {
             return;
        }
    }
    public void launch()
    {
           Instantiate(_object, Spawn.position, Spawn.rotation);


    }
}

