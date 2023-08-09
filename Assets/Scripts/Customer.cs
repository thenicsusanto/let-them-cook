using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject patienceSlider;

    public Transform receiptSpawnPoint;
    public GameObject newRecipe;
    bool patience;

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

        for (int i = 0; i < checkPointsCollectPrefab.transform.childCount; i++)
        {
            collectPoints.Add(checkPointsCollectPrefab.transform.GetChild(i));
        }

        for (int i = 0; i < checkPointsLeavePrefab.transform.childCount; i++)
        {
            leavePoints.Add(checkPointsLeavePrefab.transform.GetChild(i));
        }

        nextPoint = orderPoints[0];

        patienceSlider = GameObject.FindGameObjectWithTag("patience");
        patience = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
            TakeOrder();

        if (state == State.WalkingToOrder)
        if (state == State.WalkingToOrder)
        {
            MoveCustomerToOrder();
        }
        else if (state == State.WalkingToWait)
        {
            MoveCustomerToWait();
        }
        else if (state == State.WalkingToCollect)
        {
            MoveCustomerToCollect();
        }
        else if (state == State.WalkingToLeave)
        {
            MoveCustomerToLeave();
        }

        if (state == State.WaitingForFood || state == State.WaitingToOrder)
        {
            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), Time.deltaTime * rotationSpeed);
        }
        else
        {
            RotateCustomer();
        }

        if (patienceSlider.GetComponent<Image>().fillAmount > 0.97 && patience)
        {
            patience = false;
            //Destroy(newRecipe);
            newRecipe = null;
            //insert angry leaving sound
        }

    }

    #region Movement
    void MoveCustomerToOrder()
    {
        if (transform.position == nextPoint.position)
        {
            nextPointIndex++;
            if (nextPointIndex >= orderPoints.Count)
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
        order.menuItems.Sort((a, b) => string.Compare(a.foodName, b.foodName));
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
        lookRotation = Quaternion.LookRotation(direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    #endregion

    public void TakeOrder()
    {
        newRecipe = Instantiate(recipePrefab, receiptSpawnPoint.position, Quaternion.identity);
        newRecipe.GetComponent<Receipt>().nameText.text = order.customerName;
        newRecipe.GetComponent<Receipt>().orderNumberText.text = order.orderNumber;
        for (int i = 0; i < order.menuItems.Count; i++)
        {
            if (i == 0) newRecipe.GetComponent<Receipt>().order1.text = order.menuItems[0].CheckOrders();
            if (i == 1) newRecipe.GetComponent<Receipt>().order2.text = order.menuItems[1].CheckOrders();
            if (i == 2) newRecipe.GetComponent<Receipt>().order3.text = order.menuItems[2].CheckOrders();
            if (i == 3) newRecipe.GetComponent<Receipt>().order4.text = order.menuItems[3].CheckOrders();
        }
        //Write code for customer to walk back and wait for food
        state = State.WalkingToWait;
        nextPoint = waitPoints[0];
        nextPointIndex = 0;
        Debug.Log("Should walk");
        patienceSlider.GetComponent<Image>().fillAmount = 0;
        patience = true;
        StartCoroutine(patienceTimer(15));

    }

    IEnumerator patienceTimer(float sec)
    {
        float timer = 0;
        while ((timer < sec) && patience)
        {
            timer += Time.deltaTime;
            patienceSlider.GetComponent<Image>().fillAmount = (timer) / sec;
            yield return null;
        }

        if(state == State.WaitingForFood)
        {
            Debug.Log("ur bad");
            //Write code to lose rating
            GameManager.Instance.LoseRep();
        }
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
        if (value1.value < value2.value)
        {
            return -1;
        }
        else if (value1.value > value2.value)
        {
            return 1;
        }
        return 0;
    }

    void CompareOrder()
    {
        for (int i = 0; i < order.menuItems.Count; i++)
        {
            if (order.menuItems[i].foodName == "ChickenTenders" && GameManager.Instance.readyFoodObject.GetComponent<MealBag>().foodInBag[i].name.Contains("Chicken"))
            {
                CreatedChickenTenders comparedItem = GameManager.Instance.readyFoodObject.GetComponent<MealBag>().foodInBag[i].GetComponent<CreatedChickenTenders>();
                order.menuItems[i].CompareTenders(comparedItem);
            }
            else if (order.menuItems[i].foodName == "HotDog" && GameManager.Instance.readyFoodObject.GetComponent<MealBag>().foodInBag[i].name.Contains("Hot"))
            {
                CreatedHotDog comparedItem = GameManager.Instance.readyFoodObject.GetComponent<MealBag>().foodInBag[i].GetComponent<CreatedHotDog>();
                order.menuItems[i].CompareHotDog(comparedItem);
            }
            else if (order.menuItems[i].foodName == "FrenchFry" && GameManager.Instance.readyFoodObject.GetComponent<MealBag>().foodInBag[i].name.Contains("French"))
            {
                CreatedFrenchFry comparedItem = GameManager.Instance.readyFoodObject.GetComponent<MealBag>().foodInBag[i].GetComponent<CreatedFrenchFry>();
                order.menuItems[i].CompareFrenchFries(comparedItem);
            }
            else if (order.menuItems[i].foodName == "Burger" && GameManager.Instance.readyFoodObject.GetComponent<MealBag>().foodInBag[i].name.Contains("Burger"))
            {
                CreatedBurger comparedItem = GameManager.Instance.readyFoodObject.GetComponent<MealBag>().foodInBag[i].GetComponent<CreatedBurger>();
                order.menuItems[i].CompareBurger(comparedItem);
            }
        }
    }
}