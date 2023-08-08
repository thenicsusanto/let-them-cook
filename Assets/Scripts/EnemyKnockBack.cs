using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
    Vector3 knockBackAngle;
    bool isDying;

    // Start is called before the first frame update
    void Start()
    {
        isDying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            if (this.name.Contains("enemy_burger"))
                GetComponent<burgerEnemyAI>().enabled = false;
            else if (this.name.Contains("french enemy"))
                GetComponent<enemyFry>().enabled = false;
            else if(this.name.Contains("hot_dog_enemy"))
                GetComponent<HotDogEnemy>().enabled = false;

            knockBackAngle = (collision.gameObject.transform.position - this.transform.position).normalized;
            float knockBackVel= collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

            knockBackAngle *= knockBackVel;

            this.GetComponent<Rigidbody>().velocity = knockBackAngle;

            isDying = true;

            
        }

        if (isDying)
        {
            Destroy(this.gameObject);
            //sounds
        }
            
    }
}
