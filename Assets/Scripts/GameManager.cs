using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject readyFoodObject;
    public int rating = 3;
    public int money;
    public bool grillOn;

    public int health = 100;

    public Image healthSlider;

    public static int healthFinal = 100;
    public GameObject star1, star2, star3;

    public TextMeshProUGUI moneyText;

    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Ending Screen"))
        {
            healthFinal = health;

            healthSlider.fillAmount = ((float)health / 100.0f);

            if (health <= 0)
            {
                LoseGame();
            }

        }
    }

    public void LoseRep()
    {
        if (GameManager.Instance.rating == 3)
        {
            GameManager.Instance.rating--;
            star1.SetActive(false);
        }
        else if (GameManager.Instance.rating == 2)
        {
            GameManager.Instance.rating--;
            star2.SetActive(false);
        }
        else if (GameManager.Instance.rating == 1)
        {
            GameManager.Instance.rating--;
            star3.SetActive(false);
        }

        if (GameManager.Instance.rating <= 0)
        {
            LoseGame();
        }
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        moneyText.text = money.ToString();
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("Ending Screen");
    }
}
