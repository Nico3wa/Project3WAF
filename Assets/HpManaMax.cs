using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HpManaMax : MonoBehaviour
{
    [SerializeField] InputActionReference _using;
    [SerializeField] PlayerStat _playerStat;

    private void Start()
    {
        _using.action.started += UsingStart;
      }

    private void UsingStart (InputAction.CallbackContext obj)
    {
        _playerStat.CurrentKi = 100;
        _playerStat.CurrentLife = 500;
    }
}
