using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialProxy : MonoBehaviour
{
    [SerializeField] Special1 _sp1;


    public void launch()
    {
        _sp1.launch();
    }
}
