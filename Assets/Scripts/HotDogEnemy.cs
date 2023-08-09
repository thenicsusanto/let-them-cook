using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogEnemy : MonoBehaviour
{
    public GameObject attackDog;
    public GameObject player;
    public ParticleSystem deathEffect;
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
            TheAudioManager.Instance.PlaySFX("HotDogShot");
            StartCoroutine(shootHotDog());
        }
    }

    IEnumerator shootHotDog()
    {
        yield return new WaitForSeconds(7f);
        toFire = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pan"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            TheAudioManager.Instance.PlaySFX("PanHit");
            Destroy(gameObject, 0.6f);
        }

        if (collision.gameObject.CompareTag("Stab"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            TheAudioManager.Instance.PlaySFX("Stab");
            Destroy(gameObject);
        }
    }
}
