using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkProxy : MonoBehaviour
{
    [SerializeField] atk _attack;
    // Start is called before the first frame update
    public void LaunchAttack()
    {
        _attack.LaunchAttack();
    }
}
