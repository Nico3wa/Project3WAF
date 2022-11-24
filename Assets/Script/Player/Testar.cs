using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testar : MonoBehaviour
{

    [SerializeField] List<ImEnemy> _savedCharacter;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.attachedRigidbody == null) return;
        var h = col.attachedRigidbody.GetComponent<ImEnemy>();
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
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.attachedRigidbody == null) return;
        var h = col.attachedRigidbody.GetComponent<ImEnemy>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {
                _savedCharacter.Remove(h);
            }
        }
    }
    public void LaunchUp()
    {
        if (_savedCharacter != null)
        {
            //_savedCharacter.Damage(_MyDamage);

            //for (int i = 0; i < _savedCharacter.Count; i++)
            //{
            //    _savedCharacter[i].Damage(_MyDamage);
            //}

            foreach (ImEnemy el in _savedCharacter)
            {
                el.Rb.mass = 1;
               el.Rb.AddForce(transform.up * 5000f);
                StartCoroutine(ResetForce());
                IEnumerator ResetForce()
                {
                    yield return new WaitForSeconds(0.5f);
                    el.Rb.mass = 20;
                }
            }
        }
    }

    public void LauncHDown()
    {
        if (_savedCharacter != null)
        {
            //_savedCharacter.Damage(_MyDamage);

            //for (int i = 0; i < _savedCharacter.Count; i++)
            //{
            //    _savedCharacter[i].Damage(_MyDamage);
            //}

            foreach (ImEnemy el in _savedCharacter)
            {
                el.Rb.mass = 1;
               el.Rb.AddForce(-transform.up * 5000f);
                StartCoroutine(ResetForce());
                IEnumerator ResetForce()
                {
                    yield return new WaitForSeconds(0.5f);
                    el.Rb.mass = 20;
                }
            }
        }


    }
}

