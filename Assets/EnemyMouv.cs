using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State { IDLE, Run, Walk, Attack, Reset, }
public class EnemyMouv : MonoBehaviour
{
    [SerializeField] EnemySo _myso;
    [SerializeField] float _currenthp;
    [SerializeField] float _myspeed;
    [SerializeField] string _name;
    [SerializeField] Animator _myAnimator;
    [SerializeField] Transform _root;
    [SerializeField] bool _CanAttack;
    [SerializeField] float _CD;

    [SerializeField] triggerAttack _atk;    
    [SerializeField] DetectPlayer _detect;
    State _State;

    public float CD { get => _CD; }
    public Animator MyAnimator { get => _myAnimator; set => _myAnimator = value; }
    public bool CanAttack { get => _CanAttack; set => _CanAttack = value; }
    public State State1 { get => _State; set => _State = value; }

    void Start()
    {
        _State = State.IDLE;
        _currenthp = _myso.Maxhp;
        _myspeed = _myso.Speed;
        _name = _myso.Name;
        _CD = _myso.AttackCD;
        _CanAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_detect.Player == null) return;
       else {
            switch (_State)
            {
                case State.IDLE:

                    if (_detect.Player != null)
                    {
                        _State = State.Walk;
                    }

                    if (_detect.Player == null)
                    {

                    }


                    break;
                case State.Walk:
                    // Walk Decision
                    if (_detect.Player != null)
                    {
                    if (transform.position.x != _detect.Player.transform.position.x)
                    {
                      
                        transform.position = Vector2.MoveTowards(transform.position, _detect.Player.transform.position, _myspeed * Time.deltaTime);
                    if (_atk.SavedCharacter != null) _State = State.Attack ;
                    }


           /*         if (_atk.AttackRoutine1 != null && _CanAttack == false)
                    {
                        _State = State.Attack;
                    }
                    if (_detect.Player == null)
                    {
                        _State = State.IDLE;
                    }*/

                          }
                    else _State = State.IDLE;

                    break;
                case State.Attack:
                    if (_myAnimator.GetBool("isAttacking") == true && _atk.SavedCharacter != null)
                    {

                    }
                    else _State = State.IDLE;
                    
                    break;
            }
        if (transform.position.x < _detect.Player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (transform.position.x > _detect.Player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(_State == State.Walk && _myAnimator.GetBool("isAttacking") == false)
           {
             _myAnimator.SetBool("isWalking", true);
            }
            else
            {
            _myAnimator.SetBool("isWalking", false );
            }
     }

      /*  if (_State == State.Walk && _detect.Player != null )
        {
            _myAnimator.SetBool("isWalking", true);
        }
        else
        {
            _myAnimator.SetBool("isWalking", false);
        }*/
    }
}
