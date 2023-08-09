using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public int health = 100;

    public Image healthSlider;

    public static int healthFinal = 100;
    public GameObject star1, star2, star3;

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

            if (health <= 0) {
                LoseGame();
            }

        }
    }

    public void LoseRep()
    {
        if(GameManager.Instance.rating == 3)
        {
            GameManager.Instance.rating--;
            star1.SetActive(false);
        }
        else if (GameManager.Instance.rating == 2) 
        {
            GameManager.Instance.rating--;
            star2.SetActive(false);
        }
        else if(GameManager.Instance.rating == 1)
        {
            GameManager.Instance.rating--;
            star3.SetActive(false);
        }

        if(GameManager.Instance.rating <= 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("EndingScreen");
    }

}
