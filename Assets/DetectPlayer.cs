using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] List<GameObject> _target;
    [SerializeField] EnemyMouv _Action;

    GameObject _player;

    public GameObject Player { get => _player; }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.attachedRigidbody == null) return;
        var h = c.attachedRigidbody.GetComponentInParent<PlayerStat>();
        if (h != null)
        {
            if (_target.Contains(h.gameObject))
            {

            }
            else
            {
                _target.Add(h.gameObject);
                _player = _target[0];
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.attachedRigidbody) return;
        var h = collision.attachedRigidbody.GetComponentInParent<PlayerStat>();
        if (h != null)
        {
            if(_target.Contains(collision.gameObject) == h)
            {
                _target.Remove(h.gameObject);
            }
        }
    }

}
