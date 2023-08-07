using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Burger")]
public class Burger : OrderItem
{
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
        if(hasCheese && dish.hasCheese)
        {
            Debug.Log("Cheese is correct");
        }
        else if(hasLettuce && dish.hasLettuce)
        {
            Debug.Log("Lettuce is correct");
        }
    }

    public override string CheckOrders()
    {
        if (hasCheese)
        {
            cheese = "with cheese";
        }
        if (hasLettuce)
        {
            lettuce = "with lettuce";
        }

        return "1x " + "Hotdog " + cheese + lettuce;
    }
}
