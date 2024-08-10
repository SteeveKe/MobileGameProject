using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerSystem;
    private IceCreamTemplate _iceCreamTemplate;

    public IceCreamTemplate IceCreamTemplate => _iceCreamTemplate;
    
    //singleton
    private void Awake()
    {
        if (!GameManagerSystem)
        {
            GameManagerSystem = this;
        }
        else
        {
            Destroy(this);
        }
        
        _iceCreamTemplate = new IceCreamTemplate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
