using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderItem : ScriptableObject
{
    public string foodName;
    public int cost;
    public virtual string CheckOrders() 
    {
        return null;
    }

    public virtual void CompareTenders(CreatedChickenTenders dish)
    {

    }
    public virtual void CompareHotDog(CreatedHotDog dish)
    {

    }
    public virtual void CompareFrenchFries(CreatedFrenchFry dish)
    {

    }
    public virtual void CompareBurger(CreatedBurger dish)
    {

    }
}
