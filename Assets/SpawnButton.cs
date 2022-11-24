using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] GameObject _Pantin;
    [SerializeField] Transform _positon;
    [SerializeField] Management _mana;
    
  public void spawn()
    {
        if (_mana.SavedCharacter.Count == 0) Instantiate(_Pantin,_positon.position,_positon.rotation);
    }
}
