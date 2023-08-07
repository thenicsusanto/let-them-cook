using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Tenders")]
public class Tenders : OrderItem
{
    public int tenderAmount;

    private void OnEnable()
    {
        value = 0;
    }

    public override string CheckOrders()
    {
        return tenderAmount.ToString() + "x" + " Chicken Tenders";
    }

    public override void CompareTenders(Tenders dish)
    {
        if(dish.tenderAmount == tenderAmount)
        {
            Debug.Log("Tenders Amount matches");
        }
    }
}