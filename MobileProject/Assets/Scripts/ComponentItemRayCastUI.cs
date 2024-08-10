using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentItemRayCastUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;

    //activate all raycast of UI component
    public void ActivateRayCast()
    {
        text.raycastTarget = true;
        image1.raycastTarget = true;
        image2.raycastTarget = true;
    }
    
    //deactivate all raycast of UI component
    public void DeactivateRayCast()
    {
        text.raycastTarget = false;
        image1.raycastTarget = false;
        image2.raycastTarget = false;
    }
}
