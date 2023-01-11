using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy; // le vrais enemy 
    [SerializeField] List<GameObject> _savedCharacter;
    [SerializeField] Rigidbody2D _rb;
    private int number;
    public GameObject Player { get => _player; set => _player = value; }
    public GameObject Enemy { get => _enemy; set => _enemy = value; }
    public int Number { get => number; set => number = value; }
    public List<GameObject> SavedCharacter { get => _savedCharacter; set => _savedCharacter = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;
        if (collision.gameObject == _enemy)
        {
            if (SavedCharacter.Contains(_enemy))
            {

            }
            else
            {
                SavedCharacter.Add(collision.gameObject);
            }
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (_enemy != null) return;
        if (_enemy == null)
        {
           _enemy = collision.transform.parent.gameObject;
        }

        if (collision.attachedRigidbody == null) return;
        if (collision.gameObject == _enemy)
        {
            if (SavedCharacter.Contains(_enemy))
            {

            }
            else
            {
           SavedCharacter.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // if (collision != _enemy) return;
        if (collision.gameObject == _enemy) SavedCharacter.Remove(collision.gameObject);
    }

    private void Update()
    {
        if (SavedCharacter != null )
        {
            number = 1;
        }
        else 
        {
            number = 0;
         }
    }
}
