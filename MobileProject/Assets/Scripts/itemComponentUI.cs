using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class itemComponentUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private new TMP_Text name;
    [SerializeField] private int index;
    [SerializeField] private Transform parentTransform;
    private UIiceCreamMenu _uISelectorMenu;

    public UIiceCreamMenu UISelectorMenu
    {
        get => _uISelectorMenu;
        set => _uISelectorMenu = value;
    }

    public int Index
    {
        get => index;
        set => index = value;
    }

    public void SetIcon(Sprite sprite)
    {
        _icon.sprite = sprite;
    }

    public void SetName(string iconName)
    {
        name.text = iconName;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _uISelectorMenu.SetEmptyComponent(transform.parent, index);
        parentTransform = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentTransform);
        transform.SetSiblingIndex(index);
        _uISelectorMenu.RemoveEmptyComponent();
    }
}
