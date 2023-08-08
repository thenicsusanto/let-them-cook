using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private List<Transform> orderPoints = new List<Transform>();
    [SerializeField] private List<Transform> waitPoints = new List<Transform>();
    [SerializeField] private List<Transform> collectPoints = new List<Transform>();
    [SerializeField] private List<Transform> leavePoints = new List<Transform>();
    [SerializeField] private float objectSpeed;
    [SerializeField] private GameObject checkPointsOrderPrefab;
    [SerializeField] private GameObject checkPointsWaitPrefab;
    [SerializeField] private GameObject checkPointsCollectPrefab;
    [SerializeField] private GameObject checkPointsLeavePrefab;
    [SerializeField] private float rotationSpeed;
    int nextPointIndex;
    Transform nextPoint;
    Quaternion lookRotation;
    Vector3 direction;

    public Order order;
    [SerializeField] private GameObject recipePrefab;

    [SerializeField] private State state;

    public enum State
    {
        WalkingToOrder,
        WalkingToWait,
        WaitingForFood,
        WaitingToOrder,
        WalkingToCollect,
        WalkingToLeave,
        Delaying
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.WalkingToOrder;

        for (int i = 0; i < checkPointsOrderPrefab.transform.childCount; i++)
        {
            orderPoints.Add(checkPointsOrderPrefab.transform.GetChild(i));
        }

        for (int i = 0; i < checkPointsWaitPrefab.transform.childCount; i++)
        {
            waitPoints.Add(checkPointsWaitPrefab.transform.GetChild(i));
        }

        for(int i = 0; i < checkPointsCollectPrefab.transform.childCount; i++)
        {
            collectPoints.Add(checkPointsCollectPrefab.transform.GetChild(i));
        }

        for (int i = 0; i < checkPointsLeavePrefab.transform.childCount; i++)
        {
            leavePoints.Add(checkPointsLeavePrefab.transform.GetChild(i));
        }

        nextPoint = orderPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.WalkingToOrder)
        {
            MoveCustomerToOrder();
        }
        else if(state == State.WalkingToWait)
        {
            MoveCustomerToWait();
        }
        else if(state == State.WalkingToCollect)
        {
            MoveCustomerToCollect();
        }
        else if(state == State.WalkingToLeave)
        {
            MoveCustomerToLeave();
        }
        RotateCustomer();
    }

    #region Movement
    void MoveCustomerToOrder()
    {
        if(transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if(nextPointIndex >= orderPoints.Count)
            {
                state = State.WaitingToOrder;
                return;
            }
            nextPoint = orderPoints[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            //transform.LookAt(nextPoint.position, Vector3.up);
        }
    }

    void MoveCustomerToWait()
    {
        if (transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if (nextPointIndex >= waitPoints.Count)
            {
                state = State.WaitingForFood;
                return;
            }
            nextPoint = waitPoints[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            //transform.LookAt(nextPoint.position, Vector3.up);
        }
    }

    void MoveCustomerToCollect()
    {
        if (transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if (state != State.Delaying && nextPointIndex >= collectPoints.Count)
            {
                StartCoroutine(CollectFood());
                state = State.Delaying;
                return;
            }
            nextPoint = collectPoints[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            //transform.LookAt(nextPoint.position, Vector3.up);
        }
    }

    IEnumerator CollectFood()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.readyFoodObject.transform.SetParent(gameObject.transform);
        GameManager.Instance.readyFoodObject.transform.localPosition = Vector3.zero;
        GameManager.Instance.readyFoodObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        //GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag.Sort();
        order.menuItems.Sort(ReorderFoodList);
        Debug.Log("Sorted...");
        CompareOrder();
        //Write code below for customer to rate order and affect rating/reputation of Jerry's kitchen
        nextPointIndex = 0;
        state = State.WalkingToLeave;
    }

    void MoveCustomerToLeave()
    {
        if (transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if (nextPointIndex >= leavePoints.Count)
            {
                //GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[0]
                //if (order.menuItems[0].CompareFood())
                
                //Compare Order code below
                Destroy(gameObject);
                GameManager.Instance.readyFoodObject = null;
                return;
            }
            nextPoint = leavePoints[nextPointIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, objectSpeed * Time.deltaTime);
            //transform.LookAt(nextPoint.position, Vector3.up);
        }
    }

    void RotateCustomer()
    {
        direction = (nextPoint.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        //lookRotation = Quaternion.LookRotation(direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    #endregion

    public void TakeOrder()
    {
        GameObject newRecipe = Instantiate(recipePrefab, new Vector3(-0.0140008926f, 0.843999982f, 0.995999992f), Quaternion.Euler(new Vector3(90, 0, 0)));
        newRecipe.GetComponent<Receipt>().order1.text = order.menuItems[0].CheckOrders();
        //newRecipe.GetComponent<Receipt>().order2.text = order.menuItems[1].CheckOrders();
        //Write code for customer to walk back and wait for food
        state = State.WalkingToWait;
        nextPoint = waitPoints[0];
        nextPointIndex = 0;

        
    }

    public void CollectOrder()
    {
        Debug.Log("Order Getting Collected...");
        //Write code for customer to walk back and collect food
        state = State.WalkingToCollect;
        nextPoint = collectPoints[0];
        nextPointIndex = 0;
    }

    public int ReorderFoodList(OrderItem value1, OrderItem value2)
    {
        if(value1.value < value2.value)
        {
            return -1;
        }
        else if(value1.value > value2.value)
        {
            return 1;
        }
        return 0;
    }

    void CompareOrder()
    {
        for (int i = 0; i < order.menuItems.Count; i++)
        {
            //if (order.menuItems[i].value == 0 && GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[i].value == 0)
            //{
            //    Tenders comparedItem = (Tenders)GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[i];
            //    order.menuItems[i].CompareTenders(comparedItem);
            //}
            //else if (order.menuItems[i].value == 1 && GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[i].value == 1)
            //{
            //    HotDog comparedItem = (HotDog)GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[i];
            //    order.menuItems[i].CompareHotDog(comparedItem);
            //}
            //else if (order.menuItems[i].value == 2 && GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[i].value == 2)
            //{
            //    FrenchFry comparedItem = (FrenchFry)GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[i];
            //    order.menuItems[i].CompareFrenchFries(comparedItem);
            //}
            //else if (order.menuItems[i].value == 3 && GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[i].value == 3)
            //{
            //    //CreatedBurger comparedItem = GameManager.Instance.readyFoodObject.GetComponent<FoodBag>().foodInBag[i];
            //    //order.menuItems[i].CompareBurger(comparedItem);
            //}
        }
    }
}