using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk : MonoBehaviour
{
    [SerializeField] List<health> _savedCharacter;

    [SerializeField] int _MyDamage;
    [SerializeField] BaseDmgSo _dmg;
    [SerializeField] PlayerStat _stat;
    public List<health> SavedCharacter { get => _savedCharacter;}

    // Start is called before the first frame update


    private void Start()
    {
        _MyDamage = _dmg.Dmg;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.attachedRigidbody == null) return;
        var h = col.attachedRigidbody.GetComponent<health>();
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
        var h = col.attachedRigidbody.GetComponent<health>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {
                _savedCharacter.Remove(h);
            }
        }
    }

    public void LaunchAttack()
    {
        if (_savedCharacter != null)
        {
            //_savedCharacter.Damage(_MyDamage);

            //for (int i = 0; i < _savedCharacter.Count; i++)
            //{
            //    _savedCharacter[i].Damage(_MyDamage);
            //}

            foreach (health el in _savedCharacter)
            {
                _stat.CurrentKi += _stat.Gainki;
                el.Damage(_MyDamage);
            }
        }
    }
}
