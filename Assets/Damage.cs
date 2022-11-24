using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Instanciate inst;
    [SerializeField] List<health> _savedCharacter;
    [SerializeField] int damage;

    bool _Aply;
    private void Start()
    {
        damage = inst.Dmg;
        _Aply = true;
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.attachedRigidbody == null) return;

        var h = c.attachedRigidbody.GetComponent<health>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {

            }
            else
            {
                _savedCharacter.Add(h);
            }

        }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        if (c.attachedRigidbody == null) return;

        var h = c.attachedRigidbody.GetComponent<health>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {
                if(_Aply == true)
                {
                    c.attachedRigidbody.mass = 1;
                    c.attachedRigidbody.AddForce(_rb.velocity * 0.2f, ForceMode2D.Impulse);
                    foreach (health el in _savedCharacter)
                    {
                        _Aply = false;
                        el.Damage(damage);
                        StartCoroutine(Dmge());
                    }
                }

            }
            else
            {
                return;
            }

        }
    }
    private IEnumerator Dmge()
    {
        yield return new WaitForSeconds(0.2f);
        _Aply = true;
    }

}


