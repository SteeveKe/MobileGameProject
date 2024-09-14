using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class IceCreamComponentPlacement : MonoBehaviour
{
    [SerializeField] private List<Transform> componentTransform;
    private int _maxCount;
    private int _count;

    public List<Transform> ComponentTransform => componentTransform;

    public int MaxCount => _maxCount;

    public int Count => _count;

    private void Start()
    {
        _count = 0;
        _maxCount = componentTransform.Count;
    }

    //Instantiate and place selected ice cream component
    public GameObject PlaceComponent(GameObject prefab)
    {
        GameObject component = null;

        if (_count < _maxCount)
        {
            component = Instantiate(prefab, componentTransform[_count]);
            component.transform.localPosition = componentTransform[_count].localPosition;
            _count++;
        }
        else
        {
            Debug.Log("component max capacity reach");
        }
        
        return component;
    }
}
