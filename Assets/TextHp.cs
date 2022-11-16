using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] PlayerStat _stat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _stat.Hp;
    }
}
