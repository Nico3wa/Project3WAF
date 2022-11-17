using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyBar : MonoBehaviour
{
    [SerializeField] Slider _MySlider;
    [SerializeField] health _health;
    [SerializeField] GameObject _Slider;
    // Start is called before the first frame update


    // si le canva est en gloabal 

    //[SerializeField] Transform position; Methode 2 position enemy
    //[SerializeField] Camera _camera; CameraGlobale
    //[SerializeField] Vector3 _offset; un vector pour arranger les postion des canvas

    private void Awake()
    {
        _health = GetComponentInParent<health>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = _camera.WorldToViewportPoint(position.position + _offset); on met la postion du canva a la positon de la camera et on dit position 
        // de son point vue on dit ou donc la position enemy et o met un peux de padding avec le vector 3 pour eviter de coller l'enemie.

        if (_health.MaxHp == _health.Currenthp)
        {
            _Slider.SetActive(false);
        }
        _MySlider.maxValue = _health.MaxHp;
        _MySlider.minValue = 0;
        _MySlider.value = _health.Currenthp;
    }
}
