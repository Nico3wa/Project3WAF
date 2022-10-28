using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvement : MonoBehaviour
{
    public enum StatePlayer { IDLE, Run, Walk, }
    public enum Attack { Base, Special, UpBase, SpecialBase, none }

    public enum Jump { Jumping, Landing, none, addJump, }

    [SerializeField] ParticleSystem _DashDust;
    [SerializeField] ParticleSystem run;

    [SerializeField] InputActionReference _MoveInput;
    [SerializeField] InputActionReference _AttackInput;
    [SerializeField] InputActionReference _JumpInput;
    //    [SerializeField] InputActionReference _dash;

    [SerializeField] Transform _raycastRoot, _raycastRoot2;
    [SerializeField] Transform _raycastHead;
    [SerializeField] Vector3 _head;
    [SerializeField] Vector3 raycastDirection;
    public bool _isGrounded;
    [SerializeField] Transform _root;
    [SerializeField] float _speed;
    [SerializeField] float _MovingThreshold;
    Vector2 _playerMovement;
    [SerializeField] Animator _animator;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _MoveAttack;
    [SerializeField] float _currentspeed;
    [SerializeField] float _jumpPower;
    [SerializeField] AnimationCurve[] _JumpHeight;

    private bool candash;
    private bool isdash;
    [SerializeField] float dashingPower;
    private float dashingCooldown = 1f;
    private float dashingTime = 0.2f;

    public Vector2 PlayerMovement { get => _playerMovement; set => _playerMovement = value; }
    public Animator Animator { get => _animator; set => _animator = value; }
    public Attack AttackState { get => _Attack; set => _Attack = value; }
    public StatePlayer PlayerState { get => _playerState; set => _playerState = value; }

    StatePlayer _playerState;
    Attack _Attack;
    Jump _jump;

    Coroutine _jumpUpRoutine;
    int _jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        _playerState = StatePlayer.IDLE;
        _Attack = Attack.none;
        _currentspeed = _speed;
        // attack 
        _AttackInput.action.started += AttackStart;
        _AttackInput.action.started += AttackEnd;

        // movement
        _MoveInput.action.started += _MoveStart;
        _MoveInput.action.performed += updateMove;
        _MoveInput.action.canceled += endMove;


        // Jump
        _JumpInput.action.started += JumpStart;
        _JumpInput.action.canceled += JumpStop;

        // Dash
        //_dash.action.started += StartDash;
        //state
        _jump = Jump.none;

        candash = true;
    }

    /*  private void StartDash(InputAction.CallbackContext obj)
      {
          Debug.Log("Dash");
          //if (candash)
          //{
          //    _playerMovement = obj.ReadValue<Vector2>();
          //    StartCoroutine(Dash());
          //}
      }*/

    private void JumpStart(InputAction.CallbackContext obj)
    {
        #region JumpMode
        // if spamming jump
        if (_jumpCount >= _JumpHeight.Length) return;
        // Stop last jump routine
        if (_jumpUpRoutine != null)
        {
            StopCoroutine(_jumpUpRoutine);
            _jumpUpRoutine = null;
        }
        if (_jumpCount > 0)
        {
            _animator.SetTrigger("double");
        }


        _jumpUpRoutine = StartCoroutine(JumpRoutine()); // on fait devenir JumpUpRoutine en la Coroutine JumpRoutine

        IEnumerator JumpRoutine()
        {
            Debug.Log($"Jump count {_jumpCount}");
            var currentCurve = _JumpHeight[_jumpCount]; // on crée une variable pour changer la courbe en fonction du nombre de saut effectuer
            _jumpCount++; // notre nombre de saut
            float time = 0f; // un float pour créer un valeur de Temp d'appui
            Vector3 startPos = transform.position; // on créer un vector 3 pour enregistré notre position initial

            // variable pour evité que notre courbe actuel dépasse ne puisse pas dépasser sont nombre de point -1 car on est dans un tableau
            var lastTime = currentCurve.keys[currentCurve.keys.Length - 1].time;

            while (time < lastTime) // on boucle tant que notre temps actuel est inférieux a notre Dernier temps
            {
                yield return null;
                time += Time.deltaTime; // le temps on le fait correspondre au temps de la dernier frame/action efféctuer
                // et la on fait bouger notre joueur en bougeant que sa Position Y initial avec StartPos mais on laisse les postion x et z
                // etre manoeuvrable par d'autre action et bien sur sa suis la courbe jusqu'a sont le temps actuel.
                transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z) +
                    (Vector3.up * currentCurve.Evaluate(time));

                var hit2 = Physics2D.Raycast(_raycastHead.position, _head, _head.magnitude, LayerMask.GetMask("Ground"));
                if (hit2.collider)
                {
                    Debug.DrawLine(_raycastHead.position, _raycastHead.position + _head, Color.red);
                    StopCoroutine(_jumpUpRoutine);
                    _jumpUpRoutine = null;
                }
                else
                {
                    Debug.DrawLine(_raycastHead.position, _raycastHead.position + _head, Color.magenta);
                }
            }
            _jumpUpRoutine = null;
        }
        #endregion
        /* if (_isGrounded == true)
         {
             _animator.SetTrigger("Jump");
             _rb.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
             _jump = Jump.Jumping;
         }*/
    }

    private void JumpStop(InputAction.CallbackContext obj)
    {
        if (_jumpUpRoutine != null)
        {
            StopCoroutine(_jumpUpRoutine);
            _jumpUpRoutine = null;
        }

    }

    private void AttackEnd(InputAction.CallbackContext obj)
    {
        _Attack = Attack.none;
    }

    private void AttackStart(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("attack");
        _Attack = Attack.Base;
    }

    private void endMove(InputAction.CallbackContext obj)
    {
        _playerMovement = new Vector2(0, 0);
        _animator.SetBool("Mouv", false);
        _playerState = StatePlayer.IDLE;
    }

    private void updateMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();
        if (_jump == Jump.Landing)
        {
            _playerMovement = obj.ReadValue<Vector2>();
        }
    }

    float _lastInputTime;
    Vector2 _lastDirection;
    [SerializeField] float _doubleTapInterval = 0.5f;

    private void _MoveStart(InputAction.CallbackContext obj)
    {
        var interval = Time.time - _lastInputTime;
        var inputSign = Mathf.Sign(obj.ReadValue<Vector2>().x);
        bool hasSameSign = inputSign == Mathf.Sign(_lastDirection.x);

        if (interval < _doubleTapInterval &&
            candash &&
            hasSameSign)
        {
            Debug.Log("Dash");
            Dash();
            StartCoroutine(Dash(inputSign));
        }

        _lastInputTime = Time.time;
        _lastDirection = obj.ReadValue<Vector2>();
        if (_isGrounded)
        {
            _playerMovement = obj.ReadValue<Vector2>();
            _playerState = StatePlayer.Walk;
            _animator.SetBool("Mouv", true);
        }
        else if (_jump == Jump.Landing)
        {
            _playerMovement = obj.ReadValue<Vector2>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isdash)
        {
            return;
        }


        //  SpeedChange---------------
        if (_playerState == StatePlayer.Walk & _Attack == Attack.Base)
        {
            _currentspeed = _MoveAttack;

        }
        else if (_playerState == StatePlayer.Walk & _Attack == Attack.none || _jump == Jump.Landing)
        {
            _currentspeed = _speed;
        }

        //----------------------

        // GroundCheck-----------
        var hit = Physics2D.Raycast(_raycastRoot.position, raycastDirection, raycastDirection.magnitude, LayerMask.GetMask("Ground"));
        var hit1 = Physics2D.Raycast(_raycastRoot2.position, raycastDirection, raycastDirection.magnitude, LayerMask.GetMask("Ground"));
        if ((hit.collider != null || hit1.collider != null) && _jumpUpRoutine == null)
        {
            Debug.DrawLine(_raycastRoot.position, _raycastRoot.position + raycastDirection, Color.magenta);
            Debug.DrawLine(_raycastRoot2.position, _raycastRoot2.position + raycastDirection, Color.magenta);
            _isGrounded = true;
            _jumpCount = 0;
            // Debug.Log("jump coun=> 0");
        }
        else
        {
            Debug.DrawLine(_raycastRoot.position, _raycastRoot.position + raycastDirection, Color.red);
            Debug.DrawLine(_raycastRoot2.position, _raycastRoot2.position + raycastDirection, Color.red);
            _isGrounded = false;
        }
        //   --------------------


        // State Change -----------
        if (_isGrounded == true)
        {
            _jump = Jump.none;
        }
        else
        {
            _jump = Jump.Landing;
        }

        if (_jump == Jump.Landing)
        {
            _animator.SetBool("Landing", true);
        }
        else
        {
            _animator.SetBool("Landing", false);
        }

        _animator.SetBool("Grounded", _isGrounded);
        // ---------------------------- 

    }
    private void FixedUpdate()
    {
        if (isdash)
        {
            return;
        }
        // Mouvement -----------
        if (_playerState == StatePlayer.Walk || _jump == Jump.Landing)
        {
            _root.transform.Translate(_playerMovement * Time.fixedDeltaTime * _currentspeed, Space.World);
            if (_playerMovement.x > 0)
            {
                _root.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (_playerMovement.x < 0)   //left
            {
                _root.rotation = Quaternion.Euler(0, 180, 0);

            }
        }

        if (_playerState == StatePlayer.Walk)
        {
            //Run();
            if (run.isPlaying == false)
            {
                run.Play();
            }
            Debug.Log("start");
        }
        else
        {
            if (run.isPlaying)
            {
                run.Stop();
            }
            Debug.Log("stop");

        }
        //---------------
    }

    private IEnumerator Dash(float sign)
    {
        _animator.SetTrigger("Dash");
        candash = false;
        isdash = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0;
        _rb.velocity = new Vector2(sign * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        _rb.gravityScale = originalGravity;
        isdash = false;
        yield return new WaitForSeconds(dashingCooldown);
        candash = true;
    }

    private void Dash()
    {
        _DashDust.Play();
    }
    private void Run()
    {
        run.Play();
    }
}
