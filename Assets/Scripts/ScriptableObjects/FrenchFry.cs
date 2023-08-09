using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/FrenchFry")]
public class FrenchFry : OrderItem
{
    public OrderSize orderSize;
    public override string CheckOrders()
    {
        return "1x " + orderSize.ToString() + " French Fries";
    }
    private void OnEnable()
    {
        value = 2;
    }

    //public override void CompareFrenchFries(FrenchFry dish)
    //{
    //    if (dish.orderSize == orderSize)
    //    {
    //        Debug.Log("Ordersize matches");
    //    }
    //}
}

public enum OrderSize
{
    Small,
    Medium,
    Large
}
