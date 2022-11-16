using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextKi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] PlayerStat _stat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _text.text = _stat.Ki;
    }
}
