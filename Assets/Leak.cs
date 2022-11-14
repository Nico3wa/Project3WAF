using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : StateMachineBehaviour
{
    [SerializeField] mouvProx _mouv;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _mouv.CanMoveAtk = true;
    }
    
}
