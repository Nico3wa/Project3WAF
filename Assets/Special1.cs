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
 
    [SerializeField] PlayableDirector GetsugaTensho;
    [SerializeField] PlayableDirector _air;

    public Transform Spawn { get => _spawn; set => _spawn = value; }

    private void Start()
    {
        _special.action.started += SpecialON;
        _object = Instanciate.Instance;
    }

    private void SpecialON(InputAction.CallbackContext obj)
    {
        if (_action._isGrounded && _action.Isdash == false && !_animator.GetBool("Mouv"))
        {
            GetsugaTensho.Play();
        }
        else if(!_animator.GetBool("doubleSaut") && _animator.GetBool("Landing") && _action.Isdash == false && !_animator.GetBool("Mouv"))
        {
            _air.Play();
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

