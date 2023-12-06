using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigid;

    bool isDead;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        isDead = false;
    }

    void Start()
    {
        rigid.AddForce(Vector3.down * 3f, ForceMode.Impulse);
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

    IEnumerator resetPos()
    {
        gameObject.transform.position = new Vector3(0, -4, 0);
        rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        rigid.AddForce(Vector3.down * 7f, ForceMode.Impulse);
        isDead = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "deadLine")
        {
            if(!isDead)
            {
                isDead = true;
                StartCoroutine(resetPos());
            }
        }
    }
}
