using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerPlane playerLopgic;
    public Ball ballLogic;
    public GameObject[] blocks;

    public int blockCount;

    public bool gameStart;
    public bool gameOver;

    public int playerScore;

    public UIManager uiManager;

    void Awake()
    {
        gameStart = false;
        gameOver = false;

        playerScore = 0;
    }

    void Start()
    {
        blockCount = blocks.Length;
    }

    void Update()
    {
        // ���� �� ī��Ʈ
        uiManager.count.text = blockCount.ToString();

        // ���� �� 0 �� �� ���� ����
        if(blockCount == 0)
        {
            gameStart = false;
        }
    }
}
