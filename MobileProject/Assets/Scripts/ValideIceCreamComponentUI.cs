using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ValideIceCreamComponentUI : MonoBehaviour, IDropHandler
{

    //select the ice cream component dropped
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        itemComponentUI componentUI = dropped.GetComponent<itemComponentUI>();
        Debug.Log("test");
        if (componentUI)
        {
            GameManager.GameManagerSystem.IceCreamTemplate.SelectComponent(componentUI);
        }
    }
}
