using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> tabList;
    
    //Select one ice cream component tab
    public void OnClickSelectTab(int index)
    {
        foreach (GameObject tab in tabList)
        {
            tab.SetActive(false);
        }
        
        tabList[index].SetActive(true);
    }
}
