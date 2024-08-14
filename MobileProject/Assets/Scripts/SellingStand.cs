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

    [SerializeField] private GameObject currentBase;
    [SerializeField] private GameObject currentBall;
    [SerializeField] private GameObject currentTopping;

    private void Start()
    {
        _gameManager = GameManager.GameManagerSystem;
    }

    public void DisplayIceCreamComponent(IceCream iceCreamComponent, GameObject prefab)
    {
        switch (iceCreamComponent)
        {
            case IceCreamBase baseComponent:
                currentBase = Instantiate(prefab);
                currentBase.transform.SetParent(iceCreamPos);
                currentBase.transform.localPosition = Vector3.zero;
                break;
            case IceCreamBall ballComponent:
                break;
            case IceCreamTopping toppingComponent:
                break;
            default:
                Debug.Log("Display ice cream component failed");
                break;
        }
    }
}
