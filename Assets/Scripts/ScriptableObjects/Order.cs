using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order/Order")]
public class Order : ScriptableObject
{
    public string customerName;
    public string orderNumber;
    public List<OrderItem> menuItems = new List<OrderItem>();
    public float totalCost;
}
