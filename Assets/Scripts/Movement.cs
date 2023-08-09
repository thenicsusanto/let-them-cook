using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public int health = 100;
    public bool middleThreeFingers;
    public bool indexFinger;

    public Image healthSlider;

    public static int healthFinal = 100;

    public static int customersLost = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Ending Screen"))
        {
            healthFinal = health;

            healthSlider.fillAmount = ((float)health / 100.0f);

            if (health <= 0 || customersLost == 3) { }
                SceneManager.LoadScene("EndingScreen");

        }
    }

}
