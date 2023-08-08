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
            player.GetComponent<Movement>().health -= 20;
            Destroy(this.gameObject);
        }

    }


}
