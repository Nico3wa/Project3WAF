using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class training : MonoBehaviour
{
    [SerializeField] EnemySo _myso;
    [SerializeField] float _myspeed;
    [SerializeField] string _name;
    [SerializeField] Animator _myAnimator;
    [SerializeField] Transform _root;

    [SerializeField] GameObject target;
    State _State;

    public Animator MyAnimator { get => _myAnimator; set => _myAnimator = value; }

    public State State1 { get => _State; set => _State = value; }

    void Start()
    {
        _State = State.IDLE;
        _myspeed = _myso.Speed;
        _name = _myso.Name;
    }


    private void Update()
    {
        if (transform.position.x < target.transform.position.x)
        {
            _root.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            _root.rotation = Quaternion.Euler(0, 180, 0);
        }


    }
}
