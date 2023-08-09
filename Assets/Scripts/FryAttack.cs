using Oculus.Platform.Samples.VrBoardGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FryAttack : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed;
    Vector3 direction;
    public ParticleSystem deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("CenterEyeAnchor");
        direction = (player.transform.position - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 0.1f &&
            Mathf.Abs(player.transform.position.z - transform.position.z) < 0.1f &&
            Mathf.Abs(player.transform.position.y - transform.position.y) < 0.1f)
        {
            player.GetComponentInChildren<Movement>().health -= 4;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Movement>().health -= 4;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
