using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Models;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class burgerEnemyAI : MonoBehaviour
{
    public NavMeshAgent enemyBurger;
    public GameObject player;
    /*public Animator anim;*/

    int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        StartCoroutine(MovePosition(10));
    }

  

    IEnumerator MovePosition(float sec)
    {
        float timer = 0;
        Vector3 oldPos = this.transform.position;
        Vector3 targetPos = player.transform.position;

        while (timer < sec)
        {
            timer += Time.deltaTime;
            Vector3 playerPos = Vector3.Lerp(oldPos, new Vector3(targetPos.x, transform.position.y, targetPos.z), timer / sec);

            transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Movement>().health -= 10;

        }
        else { 
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
