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

public class IceCreamTemplate : MonoBehaviour
{
    [SerializeField] private Tuple<IceCreamBase, GameObject> _iceCreamBase = null;
    [SerializeField] private Tuple<IceCreamBall, GameObject> _iceCreamBall = null;
    [SerializeField] private Tuple<IceCreamTopping, GameObject> _iceCreamTopping = null;

    //select component to ice cream template
    public void SelectComponent(itemComponentUI component)
    {
        switch (component.IceCreamComponent)
        {
            case IceCreamBase baseComponent:
                _iceCreamBase = new Tuple<IceCreamBase, GameObject>(baseComponent, component.gameObject);
                break;
            case IceCreamBall ballComponent:
                _iceCreamBall = new Tuple<IceCreamBall, GameObject>(ballComponent, component.gameObject);
                break;
            case IceCreamTopping toppingComponent:
                _iceCreamTopping = new Tuple<IceCreamTopping, GameObject>(toppingComponent, component.gameObject);
                break;
            default:
                Debug.Log("error on component selector");
                break;
        }
    }
    
    //clear ice cream template
    public void ClearIceCream()
    {
        _iceCreamBase = null;
        _iceCreamBall = null;
        _iceCreamTopping = null;
    } 
    
    //test if ice cream are correct
    public bool ValidIceCream()
    {
        return _iceCreamBase.Item1 && _iceCreamBall.Item1;
    }
}
