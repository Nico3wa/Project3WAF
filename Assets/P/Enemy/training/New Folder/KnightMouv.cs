using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMouv : MonoBehaviour
{
    [SerializeField] EnemySo _myso;
    [SerializeField] float _currenthp;
    [SerializeField] float _myspeed;
    [SerializeField] string _name;
    [SerializeField] Animator _myAnimator;
    [SerializeField] Transform _root;
    [SerializeField] bool _CanAttack;
    [SerializeField] float _CD;

    [SerializeField] KnightAtk _atk;
    [SerializeField] DetectPlayer _detect;

    public float CD { get => _CD; }
    public Animator MyAnimator { get => _myAnimator; set => _myAnimator = value; }
    public bool CanAttack { get => _CanAttack; set => _CanAttack = value; }
    // Start is called before the first frame update
    void Start()
    {
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
        else
        {

        if (transform.position.x != _detect.Player.transform.position.x)
        {
            _myAnimator.SetBool("isWalking", true);

                if (_myAnimator.GetBool("isAttack") == true || _myAnimator.GetBool("hit") == true || _myAnimator.GetBool("death") == true)
            {
                _myAnimator.SetBool("isWalking", false);
            }
        }
                if (transform.position.x < _detect.Player.transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                }
                else if (transform.position.x > _detect.Player.transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

        }
        if (_myAnimator.GetBool("isWalking") == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _detect.Player.transform.position, _myspeed * Time.deltaTime);
        }
        else return;
    }
 }
