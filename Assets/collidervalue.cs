using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidervalue : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D _my;
    [SerializeField] CapsuleCollider2D copy;
   
    [SerializeField] GameObject _bankai;
    [SerializeField] GameObject _base;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
         
        
        if (_bankai != null)
        {
            copy = _bankai.GetComponent<CapsuleCollider2D>();
            
        }
        if (_base != null)
        {
            copy = _base.GetComponent<CapsuleCollider2D>();
        }

        
        _my.offset = copy.offset;
        _my.size = copy.size;
    }
}
