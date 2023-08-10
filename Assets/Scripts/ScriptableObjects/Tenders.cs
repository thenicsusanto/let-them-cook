using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Tenders")]
public class Tenders : OrderItem
{
    public int tenderAmount;
    
    private void OnEnable()
    {
        cost = 6;
    }

    public override string CheckOrders()
    {
        return tenderAmount.ToString() + "x" + " Chicken Tenders";
    }

    public override void CompareTenders(CreatedChickenTenders dish)
    {
        if(tenderAmount == dish.tenderAmount)
        {
            Debug.Log("Perfect tender order!");
            GameManager.Instance.AddMoney(cost);
            //Write reward code for completing perfect order
        }
        else
        {
            Debug.Log("You got the wrong chicken tender number");
            GameManager.Instance.LoseRep();
            GameManager.Instance.AddMoney(cost);
        }
    }
}