using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCombat : MonoBehaviour
{
    [SerializeField] bool _combatStart;
    [SerializeField] GameObject box;

    public bool CombatStart { get => _combatStart; set => _combatStart = value; }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (CombatStart == true) box.SetActive(true);
        if (CombatStart == false) box.SetActive(false);
    }
}
