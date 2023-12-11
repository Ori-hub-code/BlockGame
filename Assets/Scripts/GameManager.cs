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
        // 남은 블럭 카운트
        uiManager.count.text = blockCount.ToString();

        // 남은 블럭 0 일 시 게임 종료
        if(blockCount == 0)
        {
            gameStart = false;
        }
    }
}
