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
    [SerializeField] bool _CanAttack;
    [SerializeField] triggerAttack _atk;
    [SerializeField] GameObject target;
    State _State;
    [SerializeField] float _CD;

    public Animator MyAnimator { get => _myAnimator; set => _myAnimator = value; }

    public State State1 { get => _State; set => _State = value; }
    public float CD { get => _CD;}
    public bool CanAttack { get => _CanAttack; set => _CanAttack = value; }

    void Start()
    {
        _CD = _myso.AttackCD;
        _State = State.IDLE;
        _myspeed = _myso.Speed;
        _name = _myso.Name;
        _CanAttack = true;
    }



    private void Update()
    {

        switch (_State)
        {
            case State.IDLE:


                break;
            case State.Walk:
                // Walk Decision


                break;
            case State.Attack:

                    if (_CanAttack == true && _atk.AttackRoutine1 != null)  // Attack dispo & pas d'attack en cours
                                                                             //  || _atk.AttackRoutine1 != null)             // En train d'attaquer

                    {
                        // Let enemy attack
                    }
                
                else
                {
                    _State = State.Reset;
                }

                break;
            case State.Reset:




                break;
            default:
                break;




        }
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
