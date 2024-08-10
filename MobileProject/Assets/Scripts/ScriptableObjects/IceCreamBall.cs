using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBall", menuName = "Ice Cream Ball")]
public class IceCreamBall : IceCream
{
    public IceCreamPart iceCreamPart = IceCreamPart.IceCreamBall;
    public IceCreamType iceCreamType;
}
