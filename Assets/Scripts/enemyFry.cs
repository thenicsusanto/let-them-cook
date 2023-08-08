using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFry : MonoBehaviour
{
    public GameObject attackDog;
    public GameObject player;

    bool toFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(shootHotDog());
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);

        if (toFire)
        {
            toFire = false;
            Vector3 yeet = transform.position;
            Instantiate(attackDog, transform.position, Quaternion.identity);

            StartCoroutine(shootHotDog());
        }
    }

    IEnumerator shootHotDog()
    {
        yield return new WaitForSeconds(1);
        toFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rightHand") && player.GetComponent<Movement>().middleThreeFingers && player.GetComponent<Movement>().indexFinger)
        {
            
            Destroy(gameObject);
        }
    }
}