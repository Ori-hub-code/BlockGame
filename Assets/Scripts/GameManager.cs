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

    // 랭킹 시스템 5위까지만 출력
    public float[] bestScore = new float[5];
    public string[] bestName = new string[5];

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
            ScoreSet(playerScore, uiManager.userName);
            uiManager.GameClear.SetActive(true);
        }
    }

    // 랭킹 시스템

    // 현재 플레이어의 점수와 이름을 받아 옴.
    public void ScoreSet(float currentScore, string currentName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore", currentScore);

        float tmpScore = 0f;
        string tmpName = "";

        for (int i = 0; i < 5; i++)
        {
            // 저장된 최고점수와 이름 가져오기
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            // 현재 점수가 랭킹에 오를 수 있을 때
            while (bestScore[i] < currentScore)
            {
                // 자리 바꾸기
                tmpScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                // 다음 반복을 위한 준비
                currentScore = tmpScore;
                currentName = tmpName;
            }
        }

        // 랭킹에 맞춰 점수와 이름 저장
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
        }
    }


}
