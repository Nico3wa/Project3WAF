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

    [SerializeField] PlayableDirector GetsugaTensho;

    public Transform Spawn { get => _spawn; set => _spawn = value; }

    private void Start()
    {
        _special.action.started += SpecialON;
        _object = Instanciate.Instance;
    }

    private void SpecialON(InputAction.CallbackContext obj)
    {
        GetsugaTensho.Play();
    }
    public void launch()
    {
           Instantiate(_object, Spawn.position, Spawn.rotation);


    }
}

