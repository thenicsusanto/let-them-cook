using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogEnemy : MonoBehaviour
{
    public GameObject attackDog;
    public GameObject player;
    public ParticleSystem enemyDeathParticle;
    bool toFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("CenterEyeAnchor");
        StartCoroutine(shootHotDog());
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);

        if (toFire)
        {
            toFire = false;
            GameObject newProjectile = Instantiate(attackDog, transform.position, Quaternion.identity);
            StartCoroutine(shootHotDog());
        }
    }

    IEnumerator shootHotDog()
    {
        yield return new WaitForSeconds(3);
        toFire = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("rightHand") && player.GetComponent<Movement>().middleThreeFingers && player.GetComponent<Movement>().indexFinger)
    //    {
    //        //Debug.Log("Puched");
    //        //Vector3 vel = other.gameObject.GetComponent<Rigidbody>().velocity;
    //        //if(vel.x != 0 || vel.z != 0 || vel.y != 0)
    //        //{
    //        //    Destroy(this.gameObject);
    //        //}
    //        Instantiate(enemyDeathParticle, transform.position, Quaternion.identity);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pan"))
        {
            Instantiate(enemyDeathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.6f);
        }

        if (collision.gameObject.CompareTag("Stab"))
        {
            Instantiate(enemyDeathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
