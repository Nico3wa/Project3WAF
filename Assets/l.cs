using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l : MonoBehaviour
{
    Management _man;
    // Start is called before the first frame update
    private void Awake()
    {
        _man = GetComponent("LevelSystem").GetComponent<Management>();
    }
    void Start()
    {
        _man = GetComponent("LevelSystem").GetComponent<Management>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
