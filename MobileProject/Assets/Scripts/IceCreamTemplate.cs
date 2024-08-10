using System;
using UnityEngine;


public enum IceCreamPart
{
    Base,
    IceCreamBall,
    Topping
}
    
public enum IceCreamType
{
    Fruity,
    Gourmet,
    Fresh
}

public class IceCreamTemplate
{
    [SerializeField] private Tuple<IceCreamBase, GameObject> _iceCreamBase;
    [SerializeField] private Tuple<IceCreamBall, GameObject> _iceCreamBall;
    [SerializeField] private Tuple<IceCreamTopping, GameObject> _iceCreamTopping;

    public IceCreamTemplate()
    {
        _iceCreamBase = new Tuple<IceCreamBase, GameObject>(null, null);
        _iceCreamBall = new Tuple<IceCreamBall, GameObject>(null, null);
        _iceCreamTopping = new Tuple<IceCreamTopping, GameObject>(null, null);
    }
    
    //select component to ice cream template
    public void SelectComponent(itemComponentUI component)
    {
        switch (component.IceCreamComponent)
        {
            case IceCreamBase baseComponent:
                _iceCreamBase = new Tuple<IceCreamBase, GameObject>(baseComponent, component.gameObject);
                Debug.Log("select base");
                break;
            case IceCreamBall ballComponent:
                _iceCreamBall = new Tuple<IceCreamBall, GameObject>(ballComponent, component.gameObject);
                Debug.Log("select ball");
                break;
            case IceCreamTopping toppingComponent:
                _iceCreamTopping = new Tuple<IceCreamTopping, GameObject>(toppingComponent, component.gameObject);
                Debug.Log("select topping");
                break;
            default:
                Debug.Log("error on component selector");
                break;
        }
    }
    
    //clear ice cream template
    public void ClearIceCream()
    {
        _iceCreamBase = new Tuple<IceCreamBase, GameObject>(null, null);
        _iceCreamBall = new Tuple<IceCreamBall, GameObject>(null, null);
        _iceCreamTopping = new Tuple<IceCreamTopping, GameObject>(null, null);
    } 
    
    //test if ice cream are correct
    public bool ValidIceCream()
    {
        return _iceCreamBase.Item1 && _iceCreamBall.Item1;
    }
}
