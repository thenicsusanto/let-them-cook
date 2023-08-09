using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{

    [SerializeField]
    List<GameObject> panels;

    // Start is called before the first frame update
    void Start()
    {
        if (Movement.healthFinal < 1)
            panels[2].SetActive(true);
        else if (Movement.customersLost > 2)
            panels[0].SetActive(true);
        else
            panels[1].SetActive(true);
    }

    public void restart() {
        SceneManager.LoadScene("MainMenu");
    }

}
