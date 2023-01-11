using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyEnemy : MonoBehaviour
{
    [SerializeField] KnightAtk _trigg;
    [SerializeField] EnemySo _so;
    public void LaunchAttack()
    {
        if (_trigg.SavedCharacter != null)
        {
            //_savedCharacter.Damage(_MyDamage);

            //for (int i = 0; i < _savedCharacter.Count; i++)
            //{
            //    _savedCharacter[i].Damage(_MyDamage);
            //}

            foreach (PlayerStat el in _trigg.SavedCharacter)
            {
                el.Damage(_so.Attack);
            }
        }
    }
}
