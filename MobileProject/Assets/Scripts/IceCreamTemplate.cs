using System;
using System.Collections.Generic;
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
    private GameObject _currentBase;
    private List<GameObject> _currentBall = new List<GameObject>();
    private List<GameObject> _currentTopping = new List<GameObject>();
    
    private Tuple<IceCreamBase, GameObject> _iceCreamBase;
    private Tuple<IceCreamBall, GameObject> _iceCreamBall;
    private Tuple<IceCreamTopping, GameObject> _iceCreamTopping;
    
    private readonly GameManager _gameManager;

    public GameObject CurrentBase
    {
        get => _currentBase;
        set => _currentBase = value;
    }

    public List<GameObject> CurrentBall
    {
        get => _currentBall;
        set => _currentBall = value;
    }

    public List<GameObject> CurrentTopping
    {
        get => _currentTopping;
        set => _currentTopping = value;
    }

    public IceCreamTemplate()
    {
        _gameManager = GameManager.GameManagerSystem;
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
                if (baseComponent.prefab != _iceCreamBase.Item2)
                {
                    _gameManager.ClearIceCream();
                    _iceCreamBase = new Tuple<IceCreamBase, GameObject>
                        (baseComponent, component.IceCreamComponent.prefab);
                    _gameManager.PlaceIceCreamComponent(_iceCreamBase.Item1, _iceCreamBase.Item2);
                    Debug.Log("select base");
                    
                    //_gameManager.TabSelector.OnClickSelectTab(1);
                }
                break;
            case IceCreamBall ballComponent:
                if (_iceCreamBase.Item1)
                {
                    _iceCreamBall = new Tuple<IceCreamBall, GameObject>
                        (ballComponent, component.IceCreamComponent.prefab);
                    _gameManager.PlaceIceCreamComponent(_iceCreamBall.Item1, _iceCreamBall.Item2);
                    Debug.Log("select ball");

                    /*
                    if (_gameManager.StandList[0].BallPlacement.Count >=
                        _gameManager.StandList[0].BallPlacement.MaxCount)
                    {
                        _gameManager.TabSelector.OnClickSelectTab(2);
                    }
                    */
                }
                break;
            case IceCreamTopping toppingComponent:
                if (_iceCreamBall.Item1)
                {
                    _iceCreamTopping = new Tuple<IceCreamTopping, GameObject>
                        (toppingComponent, component.IceCreamComponent.prefab);
                    _gameManager.PlaceIceCreamComponent(_iceCreamTopping.Item1, _iceCreamTopping.Item2);
                    Debug.Log("select topping");
                }
                break;
            default:
                Debug.Log("error on component selector");
                break;
        }
    }
    
    //clear ice cream template
    public void ClearIceCream()
    {
        _currentBase = null;
        _currentBall.Clear();
        _currentTopping.Clear();
        
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
