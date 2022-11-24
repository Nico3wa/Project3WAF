using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceProxy : MonoBehaviour
{
    [SerializeField] Testar _add;
    
    public void LaunchUp()
    {
        _add.LaunchUp();
    }
    public void LauchDown()
    {
        _add.LauncHDown();
    }

}
