using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamList : MonoBehaviour
{
    public static IceCreamList ListIceCream;
    
    [SerializeField] private List<IceCreamBase> iceCreamBaseList;
    [SerializeField] private List<IceCreamBall> iceCreamBallList;
    [SerializeField] private List<IceCreamTopping> iceCreamToppingsList;

    public List<IceCreamBase> IceCreamBaseList => iceCreamBaseList;

    public List<IceCreamBall> IceCreamBallList => iceCreamBallList;

    public List<IceCreamTopping> IceCreamToppingsList => iceCreamToppingsList;

    //singleton 
    private void Awake()
    {
        if (ListIceCream == null)
        {
            ListIceCream = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
