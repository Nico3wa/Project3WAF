using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Instanciate _spec;
    [SerializeField] LayerMask _mask;
    

    // Update is called once per frame
    void Start()
    {
        rb.velocity = transform.right * _spec.Value;
    }


    private void Update()
    {
        Destroy(gameObject, _spec.Life);
    }


}
