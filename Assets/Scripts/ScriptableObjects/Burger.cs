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
        value = 3;
    }

    public override void CompareBurger(CreatedBurger dish)
    {
        if((hasCheese && dish.hasCheese) && (hasLettuce && dish.hasLettuce) && dish.state == "grilled")
        {
            Debug.Log("Cheese is correct");
            //Write perfect order code
        }
        else
        {
            Debug.Log("Your burger is trash!");
            GameManager.Instance.rating--;
        }
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
