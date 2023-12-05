using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float maxSpeed = 20.0f;

        // x와 y 속도를 각각 최대 속도로 Clamp
        rigid.velocity = new Vector3(
            Mathf.Clamp(rigid.velocity.x, -maxSpeed, maxSpeed),
            Mathf.Clamp(rigid.velocity.y, -maxSpeed, maxSpeed),
            rigid.velocity.z
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "deadLine")
        {
            gameObject.transform.position = new Vector3(0, 1, 0);
            rigid.velocity = Vector3.zero;
        }
    }
}
