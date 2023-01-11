using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStart : MonoBehaviour
{
    [SerializeField] List<GameObject> players;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] int _enemiNum;
    [SerializeField] int _playerNum;
    [SerializeField] LayerMask _layer;
    [SerializeField] DetectCombat _detect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;
        var h = collision.attachedRigidbody.GetComponent<PlayerStat>();
        var e = collision.attachedRigidbody.GetComponent<ImEnemy>();
        if (h != null)
        {
            if (players.Contains(h.gameObject))
            {

            }
            else
            {
                players.Add(h.gameObject);
            }
        }
            if (e != null)
            {
                if (enemies.Contains(e.gameObject))
                {

                }
                else
                {
                    enemies.Add(e.gameObject);
                }
            }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;
        var h = collision.attachedRigidbody.GetComponent<PlayerStat>();
        var e = collision.attachedRigidbody.GetComponent<ImEnemy>();
        if (h != null)
        {
            if (players.Contains(h.gameObject))
            {

            }
            else
            {
                players.Add(h.gameObject);

            }
        }

        if (e != null)
        {
            if (enemies.Contains(e.gameObject))
            {

            }
            else
            {
                enemies.Add(e.gameObject);
            }
        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;
        var h = collision.attachedRigidbody.GetComponent<PlayerStat>();
        var e = collision.attachedRigidbody.GetComponent<ImEnemy>();

        if (e != null)
        {
            if (enemies.Contains(e.gameObject))
            {
                enemies.Remove(e.gameObject);
            }

        }
        if (h != null)
        {
            if (players.Contains(h.gameObject))
            {
                players.Remove(h.gameObject);
            }

        }

    }
    private void Update()
        {
            _enemiNum = enemies.Count;
            _playerNum = players.Count;
            if (players.Count != 0 && enemies.Count == 0) _detect.CombatStart = false;
            else if (players.Count != 0 && enemies.Count != 0) _detect.CombatStart = true;
        }
 }

