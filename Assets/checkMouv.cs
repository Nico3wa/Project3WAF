using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkMouv : MonoBehaviour
{
    [SerializeField] Transform _base;
    [SerializeField] GameObject _player;
    [SerializeField] Toggle _my;

    // Update is called once per frame
    private void Start()
    {
        _my.isOn = false;
    }
    void Update()
    {
        if(_player.transform.position.x < _base.transform.position.x || _player.transform.position.x > _base.transform.position.x)
        {
            if(_my.isOn == false)_my.isOn = true;
        }
        else
        {
            return;
        }
    }
}
