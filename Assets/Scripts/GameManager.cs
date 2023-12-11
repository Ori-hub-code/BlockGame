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

    // ��ŷ �ý��� 5�������� ���
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
        // ���� �� ī��Ʈ
        uiManager.count.text = blockCount.ToString();

        // ���� �� 0 �� �� ���� ����
        if(blockCount == 0)
        {
            gameStart = false;
            ScoreSet(playerScore, uiManager.userName);
            uiManager.GameClear.SetActive(true);
        }
    }

    // ��ŷ �ý���

    // ���� �÷��̾��� ������ �̸��� �޾� ��.
    public void ScoreSet(float currentScore, string currentName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore", currentScore);

        float tmpScore = 0f;
        string tmpName = "";

        for (int i = 0; i < 5; i++)
        {
            // ����� �ְ������� �̸� ��������
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            // ���� ������ ��ŷ�� ���� �� ���� ��
            while (bestScore[i] < currentScore)
            {
                // �ڸ� �ٲٱ�
                tmpScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                // ���� �ݺ��� ���� �غ�
                currentScore = tmpScore;
                currentName = tmpName;
            }
        }

        // ��ŷ�� ���� ������ �̸� ����
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
        }
    }


}
