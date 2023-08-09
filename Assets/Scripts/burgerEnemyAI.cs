using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Platform.Models;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]
public class burgerEnemyAI : MonoBehaviour
{
    public GameObject player;
    /*public Animator anim;*/
    public ParticleSystem deathEffect;
    //public Transform playerPos;
    public NavMeshAgent agent;

    int health = 10;

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

    //IEnumerator MovePosition(float sec)
    //{
    //    float timer = 0;
    //    Vector3 oldPos = transform.position;

    //    while (timer < sec)
    //    {
    //        timer += Time.deltaTime;
    //        Vector3 newPos = Vector3.Lerp(oldPos, new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z), timer / sec);

    //        transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
    //        yield return null;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {

        
        //else
        //{
        //    EnemyJump();
        //}

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
            other.GetComponent<Movement>().health -= 9;
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
