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
    [SerializeField] GameObject _final;
    [SerializeField] GameObject _initial;
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
        switch (_State)
        {
            case State.IDLE:

                if (_detect.Player != null)
                {
                    _State = State.Walk;
                }

                if (_atk.AttackRoutine1 != null && _CanAttack)
                {
                    _State = State.Attack;
                }
                if (_detect.Player == null) 
                {

                }
                if(_detect.Player == null && _initial.transform.position.x < transform.position.x)
                {
                    _State = State.Reset;
                }
              

                    break;
            case State.Walk:
                // Walk Decision
                if (_detect.Player != null && transform.position.x <= _final.transform.position.x)
                {
                    ChasePlayer();
                }
                if (_atk.AttackRoutine1 != null && _CanAttack == false)
                {
                    _State = State.Attack;
                }
                if (_detect.Player == null)
                {
                    _State = State.IDLE;
                }
                else if (_detect.Player == null && transform.position.x < _initial.transform.position.x)
                {

                    _State = State.Reset;
                }

                break;
            case State.Attack:

                if (_detect.Player != null && _atk.SavedCharacter != null)
                {
                    if (_CanAttack == false && _atk.AttackRoutine1 != null)  // Attack dispo & pas d'attack en cours
                                                                             //  || _atk.AttackRoutine1 != null)             // En train d'attaquer

                    {
                        // Let enemy attack
                    }
                    else
                    {
                        _State = State.Walk;
                    }
                }
                else
                {
                    _State = State.Reset;
                }

                    break;
            case State.Reset:

                if (transform.position.x != _initial.transform.position.x && _detect.Player == null)
                    
                {
                     
                    if (Vector3.Distance(transform.position, _initial.transform.position) > 0.01f)
                    {
 
                        _myAnimator.SetBool("isWalking", true);
                        transform.Translate((_initial.transform.position - transform.position).normalized * _myspeed * Time.deltaTime, Space.World);
                        
                        if (transform.position.x < _initial.transform.position.x)
                        {
                            _root.rotation = Quaternion.Euler(0, 0, 0);

                        }
                        else
                        {
                            _root.rotation = Quaternion.Euler(0, 180, 0);
                        }
                       
            
                }
                      
                      else
                        {
                            _myAnimator.SetBool("isWalking", false);
                            _root.rotation = Quaternion.Euler(0, 0, 0); 
                        }
                    }
                else if (_detect.Player != null && transform.position.x < _final.transform.position.x)
                {
                    ChasePlayer();
                    _State = State.Walk;
                }


                break;
            default:
                break;

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
    private void stopChasePlayer()
    {



    }
    private void ChasePlayer()
    {
        
        if (transform.position.x < _detect.Player.transform.position.x)
        {
            _root.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            _root.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (_State == State.Walk)
        {
            if(transform.position.x <= _final.transform.position.x && _detect.Player != null)
            {
                _myAnimator.SetBool("isWalking", true);
                transform.position = Vector2.MoveTowards(transform.position, _detect.Player.transform.position, _myspeed * Time.deltaTime);
            }
            if (transform.position.x <= _final.transform.position.x && _detect.Player == null)
            {
                _myAnimator.SetBool("isWalking", false);
                _State = State.Reset;
            }
        }
        else
        {
            _myAnimator.SetBool("isWalking", false);
            _State = State.IDLE;
        }
        if (_CanAttack == false && _atk.AttackRoutine1 != null)
        {
            _myAnimator.SetBool("isWalking", false);
            _State = State.Attack;
        }

        if (transform.position.x >= _final.transform.position.x)
        {
            _myAnimator.SetBool("isWalking", false);
            _State = State.IDLE;
            _root.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

}
