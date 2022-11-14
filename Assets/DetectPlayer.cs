using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] GameObject _Target;
    [SerializeField] EnemyMouv _Action;

    GameObject _player;

    public GameObject Player { get => _player; }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D c) => CheckCollision(c);
    void OnTriggerStay2D(Collider2D c) => CheckCollision(c);
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject == _Target)
        {
           _player = null;
          //  _Action.State1 = State.IDLE;
        }
    }
    public void CheckCollision(Collider2D c)
    {
        if (c.gameObject == _Target)
        {
            _player = c.gameObject;
            ;
        }
        else
        {
            return;
        }
    }
}
