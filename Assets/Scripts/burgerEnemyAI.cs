using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Platform.Models;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class burgerEnemyAI : MonoBehaviour
{
    public GameObject player;
    /*public Animator anim;*/
    public ParticleSystem deathEffect;
    //public Transform playerPos;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("CenterEyeAnchor");
        //StartCoroutine(MovePosition(10));
    }

    private void Update()
    {
        //playerPos.position = player.transform.position;
        agent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pan"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            TheAudioManager.Instance.PlaySFX("PanHit");
            Destroy(gameObject, 0.6f);
            Instantiate(deathEffect, transform.position, Quaternion.identity);

        }

        if (collision.gameObject.CompareTag("Stab"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            TheAudioManager.Instance.PlaySFX("Stab");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.health -= 9;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    //private void EnemyJump()
    //{
    //    GetComponent<Rigidbody>().AddForce(Vector3.up * 1.4f, ForceMode.Impulse);
    //}

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("rightHand"))
    //    {
    //        health -= 3;
    //        if (health < 1)
    //            Destroy(this.gameObject);

    //    }

    //}
}
