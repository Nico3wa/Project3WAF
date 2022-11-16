using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    [SerializeField] Slider _MySlider;
    [SerializeField] PlayerStat _stat;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _MySlider.minValue = 0;
        _MySlider.maxValue = _stat.MaxLife;
        _MySlider.value = _stat.CurrentLife;
        _MySlider.value = _stat.CurrentLife;
    }
}
