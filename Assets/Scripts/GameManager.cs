using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerPlane playerLopgic;
    public Ball ballLogic;
    public GameObject[] blocks;

    public Text count;
    public int blockCount;

    public bool gameStart;

    void Awake()
    {
        gameStart = false;
    }

    void Start()
    {
        blockCount = blocks.Length;
    }

    void Update()
    {
        // ���� �� ī��Ʈ
        count.text = blockCount.ToString();

        // ���� �� 0 �� �� ���� ����
        if(blockCount == 0)
        {
            gameStart = false;
        }
    }
}
