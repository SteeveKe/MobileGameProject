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
    [SerializeField] private TabSelector tabSelector;

    public List<SellingStand> StandList => standList;

    public TabSelector TabSelector
    {
        get => tabSelector;
        set => tabSelector = value;
    }

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
        tabSelector = FindObjectOfType<TabSelector>();
    }

    //Place selected ice cream component
    public void PlaceIceCreamComponent(IceCream iceCreamComponent, GameObject prefab)
    {
        foreach (SellingStand sellingStand in standList)
        {
            sellingStand.PlaceIceCreamComponent(iceCreamComponent, prefab);
        }
    }

    //Clear current ice cream
    public void ClearIceCream()
    {
        Destroy(IceCreamTemplate.CurrentBase);
        foreach (SellingStand sellingStand in standList)
        {
            sellingStand.ClearIceCream();
        }
        
        IceCreamTemplate.ClearIceCream();
    }
    
}
