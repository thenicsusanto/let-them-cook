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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.fillAmount = ((float)health / 100.0f);

        if (health <= 0) { }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void OnTrigHold(InputAction.CallbackContext context)
    {
        if(context.performed)
            indexFinger = true;
        else
            indexFinger = false;
    }

    public void OnGripHold(InputAction.CallbackContext context)
    {
        if (context.performed)
            middleThreeFingers = true;
        else
            middleThreeFingers = false;
    }
}
