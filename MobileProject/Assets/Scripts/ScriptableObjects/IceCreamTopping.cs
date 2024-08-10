using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTopping", menuName = "Ice Cream Topping")]
public class IceCreamTopping : IceCream
{
    public IceCreamPart iceCreamPart = IceCreamPart.Topping;
}
