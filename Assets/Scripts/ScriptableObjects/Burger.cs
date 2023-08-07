using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Burger")]
public class Burger : OrderItem
{
    public bool hasCheese;
    public bool hasLettuce;
    public bool hasTomatoes;
    public bool hasOnions;
    string cheese = "";
    string lettuce = "";
    string tomato = "";
    string onion = "";

    private void OnEnable()
    {
        value = 3;
    }

    public override void CompareBurger(Burger dish)
    {
        if(hasCheese && dish.hasCheese)
        {
            Debug.Log("Cheese is correct");
        }
        else if(hasLettuce && dish.hasLettuce)
        {
            Debug.Log("Lettuce is correct");
        }
        else if(hasTomatoes && dish.hasTomatoes)
        {
            Debug.Log("Tomatoes are correct");
        }
        else if(hasOnions && dish.hasOnions)
        {
            Debug.Log("Onions are correct");
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
        if(hasTomatoes)
        {
            tomato = "with tomatoes";
        }
        if(hasOnions)
        {
            tomato = "with onion";
        }

        return "1x " + "Hotdog " + cheese + lettuce + tomato + onion;
    }
}
