using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AdForce : MonoBehaviour
{

    [SerializeField] List<Rigidbody2D> _savedCharacter;
    [SerializeField] Rigidbody2D rb;


    
    private void OnTriggerEnter2D(Collider2D col)
    {
        var h = col.GetComponent<Rigidbody2D>();
        if ( h == rb )
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
        var h = col.GetComponent<Rigidbody2D>();
        if (h == rb)
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

            foreach (Rigidbody2D el in _savedCharacter)
            {
                rb.AddForce(transform.up * 5000f);
            }
        }
    }



}
