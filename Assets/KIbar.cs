using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KIbar : MonoBehaviour
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
        _MySlider.maxValue = _stat.MaxKi;
        _MySlider.value = _stat.CurrentKi;
        _MySlider.value = _stat.CurrentKi;
    }
}
