using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderItem : ScriptableObject
{
    public int value;

    public virtual string CheckOrders() 
    {
        return null;
    }

    public virtual void CompareTenders(Tenders dish)
    {

    }
    public virtual void CompareHotDog(HotDog dish)
    {

    }
    public virtual void CompareFrenchFries(FrenchFry dish)
    {

    }
    public virtual void CompareBurger(CreatedBurger dish)
    {

    }
}
