using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Burger")]
public class Burger : OrderItem
{
    //base.foodName = "Burger";
    public bool hasCheese;
    public bool hasLettuce;
    string cheese = "";
    string lettuce = "";

    private void OnEnable()
    {
        cost = 10;
    }

    public override void CompareBurger(CreatedBurger dish)
    {
        if((hasCheese && dish.hasCheese) && (hasLettuce && dish.hasLettuce) && dish.state == "grilled")
        {
            Debug.Log("Cheese is correct");
            GameManager.Instance.AddMoney(cost);
            //Write perfect order code
        }
        else
        {
            Debug.Log("Your burger is trash!");
            GameManager.Instance.LoseRep();
            GameManager.Instance.AddMoney(cost);
        }
        Debug.Log("checking commpare burger");
    }

    public override string CheckOrders()
    {
        if (hasCheese)
        {
            cheese = " with cheese";
        }
        if (hasLettuce)
        {
            lettuce = " with lettuce";
        }

        return "1x " + "Hotdog " + cheese + lettuce;
    }
}
