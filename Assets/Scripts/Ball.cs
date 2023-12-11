using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    Rigidbody rigid;

    bool isDead;
    bool started;
    public int health;

    public GameManager gameManager;
    public UIManager uiManager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        isDead = false;
        started = false;
        health = 3;
    }

    void OnEnable()
    {
        isDead = false;
        started = false;
        health = 3;
        rigid.velocity = Vector3.zero;
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

        if(gameManager.gameStart && !started && Input.anyKeyDown)
        {
            rigid.AddForce(Vector3.down * 7f, ForceMode.Impulse);
            started = true;
        }
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
                health--;
                isDead = true;

                if(health == 0)
                {
                    gameObject.transform.position = new Vector3(0, -4, 0);
                    rigid.velocity = Vector3.zero;
                    gameManager.gameOver = true;
                    gameManager.gameStart = false;
                    gameObject.SetActive(false);
                    uiManager.GameOver.SetActive(true);
                } else
                {
                    StartCoroutine(resetPos());
                }
            }
        }
    }
}
