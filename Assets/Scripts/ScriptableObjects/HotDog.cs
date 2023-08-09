using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/HotDog")]
public class HotDog : OrderItem
{
    public bool hasKetchup;
    public bool hasMustard;
    string ketchup = "";
    string mustard = "";

    private void OnEnable()
    {
        value = 1;
    }
    public override void CompareHotDog(CreatedHotDog dish)
    {
        if (hasKetchup && dish.hasKetchup || !hasKetchup && !dish.hasKetchup || dish.state == "grilled")
        {
            Debug.Log("Everything is correct");
            //Write reward code for completing perfect order
        }
        else
        {
            Debug.Log("You are wrong!");
            GameManager.Instance.rating--;
        }
    }

    public override string CheckOrders()
    {   
        if(hasKetchup)
        {
            ketchup = " with ketchup";
        }
        else
        {
            ketchup = "";
        }

        if(hasMustard)
        {
            mustard = " with mustard";
        }
        else
        {
            mustard = "";
        }

        return "1x " + "Hotdog " + ketchup + mustard;
    }
}