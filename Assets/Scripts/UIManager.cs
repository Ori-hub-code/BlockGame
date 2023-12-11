using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField idInput;
    public InputField passInput;

    List<string> idList;
    List<string> passList;

    public GameObject LoginSystem;
    public GameObject GameOver;
    public GameObject GameClear;
    public GameObject Ranking;
    public GameObject RankingBtn;

    public GameManager gameManager;
    public Ball ballLogic;

    public GameObject playerBall;
    public GameObject playerPlane;

    public Text count;
    public Text score;
    public Text health;

    public string userName;

    public Text firstUser;
    public Text secondUser;
    public Text thirdUser;
    public Text fourthUser;
    public Text fifthUser;

    public Text firstScore;
    public Text secondScore;
    public Text thirdScore;
    public Text fourthScore;
    public Text fifthScore;

    void Awake()
    {
        idList = new List<string>();
        passList = new List<string>();
    }

    void Update()
    {
        count.text = gameManager.blockCount.ToString();
        score.text = gameManager.playerScore.ToString();
        health.text = ballLogic.health.ToString();

        firstUser.text = gameManager.bestName[0].ToString();
        secondUser.text = gameManager.bestName[1].ToString();
        thirdUser.text = gameManager.bestName[2].ToString();
        fourthUser.text = gameManager.bestName[3].ToString();
        fifthUser.text = gameManager.bestName[4].ToString();

        firstScore.text = gameManager.bestScore[0].ToString();
        secondScore.text = gameManager.bestScore[1].ToString();
        thirdScore.text = gameManager.bestScore[2].ToString();
        fourthScore.text = gameManager.bestScore[3].ToString();
        fifthScore.text = gameManager.bestScore[4].ToString();
    }

    // ȸ������
    public void MakeUser()
    {

        string userId = idInput.text;
        string userPass = passInput.text;

        if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userPass))
        {
            if(idList.Contains(userId))
            {
                Debug.Log("�̹� �����ϴ� ID �Դϴ�.");
            } else
            {
                idList.Add(userId);
                passList.Add(userPass);

                Debug.Log("ID : " + userId + "    PW : " + userPass);

                idInput.text = "";
                passInput.text = "";
            }
        }
        else
        {
            Debug.Log("ȸ������ ����");
        }

        // ���� ��й�ȣ �ʿ� ���� �� �� �ڵ� ��� ���

        //if (string.IsNullOrEmpty(userId))
        //{
        //    Debug.LogWarning("����ڸ��� ������� �� �����ϴ�.");
        //    return;
        //}

        //// ����ڰ� �̹� �����ϴ��� Ȯ��
        //if (PlayerPrefs.HasKey(idInput.text))
        //{
        //    Debug.LogWarning("�̹� ����ڰ� �����մϴ�.");
        //    return;
        //}

        //// ������ ����
        //PlayerPrefs.SetString("userId", userId);
        //PlayerPrefs.Save();

        //// ��ǲ�ʵ� �ʱ�ȭ
        //idInput.text = "";
        //passInput.text = "";
    }

    // �α���
    public void Login()
    {
        if (idList.Contains(idInput.text) && passList.Contains(passInput.text) && idList.IndexOf(idInput.text) == passList.IndexOf(passInput.text))
        {
            gameManager.gameStart = true;
            LoginSystem.SetActive(false);

            userName = idInput.text;
            RankingBtn.SetActive(false);
        }
        else
        {
            Debug.Log("�α��� ����");
        }

        // ���� ��й�ȣ �ʿ� ���� �� �� �ڵ� ��� ���
        // PlayerPrefs -> ������ �����ص� ������ ������ ��.

        //if (PlayerPrefs.HasKey(idInput.text))
        //{
        //    gameManager.gameStart = true;
        //    LoginSystem.SetActive(false);
        //}
        //else
        //{
        //    Debug.Log("�α��� ����");
        //}

    }

    public void Restart()
    {
        gameManager.gameStart = true;
        gameManager.gameOver = false;
        gameManager.playerScore = 0;
        gameManager.blockCount = gameManager.blocks.Length;
        GameOver.SetActive(false);
        RankingBtn.SetActive(false);

        playerBall.SetActive(true);
        playerPlane.transform.position = new Vector3(0, -10.25f, 0);

        // ���� �ʱ�ȭ
        for (int i = 0; i < gameManager.blocks.Length; i++)
        {
            Block blockLogic = gameManager.blocks[i].GetComponent<Block>();
            blockLogic.RandomColor();
            gameManager.blocks[i].SetActive(true);
        }
    }

    public void CheckRanking()
    {
        Ranking.SetActive(true);
    }

    public void CloseRanking()
    {
        Ranking.SetActive(false);
    }
}
