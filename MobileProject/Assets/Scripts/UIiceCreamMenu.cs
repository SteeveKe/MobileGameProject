using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIiceCreamMenu : MonoBehaviour
{
    private IceCreamList _iceCreamList;

    [SerializeField] private GameObject componentUI;
    [SerializeField] private Transform coneComponentHandler;
    [SerializeField] private Transform ballComponentHandler;
    [SerializeField] private Transform toppingComponentHandler;
    [SerializeField] private Transform emptyComponent;

    public Transform EmptyComponent => emptyComponent;

    void Start()
    {
        emptyComponent.gameObject.SetActive(false);
        _iceCreamList = IceCreamList.ListIceCream;
        InitIceCreamBase();
        InitIceCreamBall();
        InitIceCreamTopping();
    }

    //add ice cream base to the tab
    private void InitIceCreamBase()
    {
        int index = 0;
        foreach (IceCreamBase iceCreamBase in _iceCreamList.IceCreamBaseList)
        {
            if (iceCreamBase)
            {
                GameObject componentItem = Instantiate(componentUI, coneComponentHandler);
                itemComponentUI itemComponentUI = componentItem.GetComponent<itemComponentUI>();
                itemComponentUI.IceCreamComponent = iceCreamBase;
                itemComponentUI.SetElementUI();
                itemComponentUI.UISelectorMenu = this;
                itemComponentUI.Index = index;
                index++;
            }
        }
    }
    
    //add ice cream ball to the tab
    private void InitIceCreamBall()
    {
        int index = 0;
        foreach (IceCreamBall iceCreamBall in _iceCreamList.IceCreamBallList)
        {
            if (iceCreamBall)
            {
                GameObject componentItem = Instantiate(componentUI, ballComponentHandler);
                itemComponentUI itemComponentUI = componentItem.GetComponent<itemComponentUI>();
                itemComponentUI.IceCreamComponent = iceCreamBall;
                itemComponentUI.SetElementUI();
                itemComponentUI.UISelectorMenu = this;
                itemComponentUI.Index = index;
                index++;
            }
        }
    }
    
    //add ice cream topping to the tab
    private void InitIceCreamTopping()
    {
        int index = 0;
        foreach (IceCreamTopping iceCreamTopping in _iceCreamList.IceCreamToppingsList)
        {
            if (iceCreamTopping)
            {
                GameObject componentItem = Instantiate(componentUI, toppingComponentHandler);
                itemComponentUI itemComponentUI = componentItem.GetComponent<itemComponentUI>();
                itemComponentUI.IceCreamComponent = iceCreamTopping;
                itemComponentUI.SetElementUI();
                itemComponentUI.UISelectorMenu = this;
                itemComponentUI.Index = index;
                index++;
            }
        }
    }

    //replace dragged component by empty object
    public void SetEmptyComponent(Transform parent, int index)
    {
        emptyComponent.gameObject.SetActive(true);
        emptyComponent.SetParent(parent);
        emptyComponent.SetSiblingIndex(index);
    }

    //replace empty object by ui component
    public void RemoveEmptyComponent()
    {
        emptyComponent.SetParent(transform);
        emptyComponent.SetAsLastSibling();
        emptyComponent.gameObject.SetActive(false);
    }
}
