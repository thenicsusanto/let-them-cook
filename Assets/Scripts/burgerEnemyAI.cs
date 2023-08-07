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
        /*anim.SetBool("Coming Closer", true);*/
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        //StartCoroutine(MovePosition(10));
    }

    private void Update()
    {
        //enemyBurger.SetDestination(player.transform.position);

        // Lerp towards the player's position
        Vector3 playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime * 0.5f);
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
        //if(collision.gameObject.CompareTag("Player"))
        //{
        //    player.GetComponent<Movement>().health -= 10;

<<<<<<< Updated upstream
        //}
        if (collision.gameObject.CompareTag("ground"))
=======
        }
        else
>>>>>>> Stashed changes
        {
            EnemyJump();
        }
    }

    private void EnemyJump()
    {
<<<<<<< Updated upstream
        GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
        Debug.Log(gameObject.name + " jumped");
=======
        GetComponent<Rigidbody>().AddForce(Vector3.up * 2, ForceMode.Impulse);
>>>>>>> Stashed changes
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
