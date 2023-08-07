using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Models;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]
public class burgerEnemyAI : MonoBehaviour
{
    public NavMeshAgent enemyBurger;
    public GameObject player;
    /*public Animator anim;*/

    public Transform playerPos;

    int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        StartCoroutine(MovePosition(10));
    }

    private void Update()
    {
        playerPos.position = player.transform.position;
    }

    IEnumerator MovePosition(float sec)
    {
        float timer = 0;
        Vector3 oldPos = transform.position;

        while (timer < sec)
        {
            timer += Time.deltaTime;
            Vector3 newPos = Vector3.Lerp(oldPos, new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z), timer / sec);

            transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Movement>().health -= 10;

        }

        else if (collision.gameObject.CompareTag("rightHand") && player.GetComponent<Movement>().middleThreeFingers && player.GetComponent<Movement>().indexFinger)
        {
            Vector3 vel = collision.gameObject.GetComponent<Rigidbody>().velocity;
            if (vel.x != 0 || vel.z != 0 || vel.y != 0.1)
            {
                Destroy(this.gameObject);
                collision.gameObject.GetComponent<ActionBasedController>().SendHapticImpulse(0.1f, 0.1f);
            }
        }
        else if (collision.gameObject.tag.Equals("Weapon"))
        {
            Destroy(this.gameObject);
        }
        else
        { 
            EnemyJump();
        }
    }

    private void EnemyJump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 1.4f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("rightHand"))
        {
            health -= 3;
            if (health < 1)
                Destroy(this.gameObject);
            
        }

    }
}
