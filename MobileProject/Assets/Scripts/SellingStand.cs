using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SellingStand : MonoBehaviour
{
    [SerializeField] private Transform iceCreamPos;
    private GameManager _gameManager;
    private IceCreamTemplate _iceCreamTemplate;

    private IceCreamComponentPlacement _ballPlacement;
    private List<IceCreamComponentPlacement> _toppingPlacement = new List<IceCreamComponentPlacement>();

    public IceCreamComponentPlacement BallPlacement => _ballPlacement;

    private void Start()
    {
        _gameManager = GameManager.GameManagerSystem;
        _iceCreamTemplate = _gameManager.IceCreamTemplate;
    }

    //Instantiate and place selected ice cream component
    public void PlaceIceCreamComponent(IceCream iceCreamComponent, GameObject prefab)
    {
        switch (iceCreamComponent)
        {
            case IceCreamBase:
                
                GameObject newBase = Instantiate(prefab, iceCreamPos);
                _iceCreamTemplate.CurrentBase = newBase;
                _ballPlacement = newBase.GetComponent<IceCreamComponentPlacement>();
                break;
            
            case IceCreamBall:
                
                GameObject newBall = _ballPlacement.PlaceComponent(prefab);
                if (newBall)
                {
                    _iceCreamTemplate.CurrentBall.Add(newBall);
                    _toppingPlacement.Add(newBall.GetComponent<IceCreamComponentPlacement>());
                }
                
                break;
            
            case IceCreamTopping:

                foreach (IceCreamComponentPlacement placement in _toppingPlacement)
                {
                    GameObject newTopping = placement.PlaceComponent(prefab);

                    if (newTopping)
                    {
                        _iceCreamTemplate.CurrentTopping.Add(newTopping);
                    }
                }
                break;
            default:
                Debug.Log("Display ice cream component failed");
                break;
        }
    }

    //clear ice cream placement
    public void ClearIceCream()
    {
        _ballPlacement = null;
        _toppingPlacement.Clear();
    }
}
