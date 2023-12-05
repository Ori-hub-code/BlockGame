using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerPlane : MonoBehaviour
{
    public float hAxis;
    public float speed;
    Vector3 moveDir;

    bool leftBlocked;
    bool rightBlocked;
    bool scaned;
    Vector3 ballDir;

    Rigidbody rigid;
    Rigidbody ballRigid;

    void Awake()
    {
        moveDir = Vector3.zero;
        leftBlocked = false;
        rightBlocked = false;
        scaned = false;

        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Ray();
    }
    void LateUpdate()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    void Move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");

        if (hAxis > 0 && !rightBlocked)
        {
            moveDir = new Vector3(hAxis, 0, 0);
        }
        else if (hAxis < 0 && !leftBlocked)
        {
            moveDir = new Vector3(hAxis, 0, 0);
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

    void Ray()
    {
        Collider hit = Physics.OverlapBox(transform.position + new Vector3(0, 0.5f, 0), new Vector3(3f, 0.5f, 1f), Quaternion.identity, LayerMask.GetMask("Ball")).FirstOrDefault();

        if (hit != null)
        {
            if (!scaned)
            {
                ballRigid = hit.GetComponent<Rigidbody>();
                ballDir = ballRigid.velocity + new Vector3(hAxis * 1.5f, 0, 0);
                scaned = true;
            }
        }
        else
        {
            scaned = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0);
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 0.5f, 0), new Vector3(3f, 0.5f, 1f));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            ballRigid.AddForce(ballDir * -1.5f, ForceMode.Impulse);
        }

        // 벽에 막히게
        if (collision.gameObject.tag == "leftWall")
        {
            leftBlocked = true;
        }
        if (collision.gameObject.tag == "rightWall")
        {
            rightBlocked = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "leftWall")
        {
            leftBlocked = false;
        }
        if (collision.gameObject.tag == "rightWall")
        {
            rightBlocked = false;
        }
    }

}
