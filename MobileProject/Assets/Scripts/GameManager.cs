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
    [SerializeField] private List<SellingStand> standList;

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

    public void DisplayIceCreamComponent(IceCream iceCreamComponent, GameObject prefab)
    {
        foreach (SellingStand sellingStand in standList)
        {
            sellingStand.DisplayIceCreamComponent(iceCreamComponent, prefab);
        }
    }
}
