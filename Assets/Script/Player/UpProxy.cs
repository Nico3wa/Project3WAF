using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpProxy : MonoBehaviour
{
    [SerializeField] AdForce _add;

    public void LaunchUp()
    {
        _add.LaunchUp();
    }

}
