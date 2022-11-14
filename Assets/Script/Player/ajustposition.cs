using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajustposition : MonoBehaviour
{
    [SerializeField] GameObject _bankai;
    [SerializeField] GameObject _base;
    [SerializeField] GameObject _me;
 
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
     

    
    }
        public void Onmove()
        {
            if (_bankai != null)
            {
                transform.position = _bankai.transform.position;
            }
            if (_base != null)
            {
                transform.position = _base.transform.position;
            }
        }
}
