using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    MeshRenderer renderer;

    public Material[] material;
    public int hp;
    int ran;
    bool damaged;

    public GameManager gameManager;

    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();

        damaged = false;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        RandomColor();
    }

    public void RandomColor()
    {
        // 색 랜덤 부여
        ran = Random.Range(0, 4);

        renderer.material = material[ran];

        switch (ran)
        {
            case 0:
                hp = 1;
                break;
            case 1:
                hp = 2;
                break;
            case 2:
                hp = 3;
                break;
            case 3:
                hp = 4;
                break;

        }
    }

    IEnumerator CanDamaged()
    {
        hp--;
        damaged = true;
        
        // 맞았을 때 색 변경
        if(ran <= 0)
        {
            ran = 0;
        } else
        {
            renderer.material = material[ran - 1];
        }

        ran--;
        yield return new WaitForSeconds(0.3f);
        damaged = false;
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            if(!damaged)
            {
                StartCoroutine(CanDamaged());

            }

            if(hp <= 0)
            {
                gameObject.SetActive(false);
                gameManager.blockCount--;

                // 점수 추가
                gameManager.playerScore += 200;
            } else
            {
                // 점수 추가
                gameManager.playerScore += 100;
            }
        }
    }
}
