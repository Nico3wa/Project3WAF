using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expulse : MonoBehaviour
{
    [SerializeField] float Push;
    [SerializeField] List<collidervalue> _savedCharacter;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var h = collision.GetComponent<collidervalue>();
        h?.GetComponentInParent<Rigidbody2D>()?.AddForce((h.transform.position - transform.position).normalized * Push);
        //  ? = null et si c pas null sa continue sur la ligne suite
         //else
        //{
        //    if (!_savedCharacter.Contains(h))
        //    {
        //        _savedCharacter.Add(h);
        //    }
        //}
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var h = collision.GetComponent<collidervalue>();
        h?.GetComponentInParent<Rigidbody2D>()?.AddForce((h.transform.position - transform.position).normalized * Push);
    }
}
