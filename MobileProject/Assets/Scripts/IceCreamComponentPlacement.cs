using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamComponentPlacement : MonoBehaviour
{
    [SerializeField] private List<Transform> componentTransform;
    private int _maxCount;
    private int count;

    public List<Transform> ComponentTransform => componentTransform;

    public int MaxCount => _maxCount;

    public int Count => count;

    private void Start()
    {
        count = 0;
        _maxCount = componentTransform.Count;
    }
}
