using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField idInput;

    List<string> idList;

    public GameObject LoginSystem;
    public GameObject GameSystem;
    public GameObject ResultSystem;
    public GameObject GameOver;
    public GameObject GameClear;
    public GameObject Ranking;
    public GameObject RankingBtn;

    // 팝업창
    public GameObject QuitPopup;
    public GameObject CheckUserNamePopUp;
    public GameObject GameStartPopUp;
    public GameObject HomePopup;
    public GameObject RankingPopup;
    public GameObject RestartPopup;

    public GameManager gameManager;
    public Ball ballLogic;

    public GameObject playerBall;
    public GameObject playerPlane;

    public Text score;
    public Text health;

    public string userName;

    public Text firstUser;
    public Text secondUser;
    public Text thirdUser;
    public Text fourthUser;
    public Text fifthUser;
    public Text sixthUser;
    public Text seventhUser;
    public Text eighthUser;
    public Text ninthUser;
    public Text tenthUser;

    public Text firstScore;
    public Text secondScore;
    public Text thirdScore;
    public Text fourthScore;
    public Text fifthScore;
    public Text sixtScore;
    public Text seventhScore;
    public Text eightScore;
    public Text ninthScore;
    public Text tenthScore;

    void Awake()
    {
        idList = new List<string>();
    }

    void Update()
    {
        score.text = gameManager.playerScore.ToString();
        health.text = ballLogic.health.ToString();

        firstUser.text = gameManager.bestName[0].ToString();
        secondUser.text = gameManager.bestName[1].ToString();
        thirdUser.text = gameManager.bestName[2].ToString();
        fourthUser.text = gameManager.bestName[3].ToString();
        fifthUser.text = gameManager.bestName[4].ToString();
        sixthUser.text = gameManager.bestName[5].ToString();
        seventhUser.text = gameManager.bestName[6].ToString();
        eighthUser.text = gameManager.bestName[7].ToString();
        ninthUser.text = gameManager.bestName[8].ToString();
        tenthUser.text = gameManager.bestName[9].ToString();

        firstScore.text = gameManager.bestScore[0].ToString();
        secondScore.text = gameManager.bestScore[1].ToString();
        thirdScore.text = gameManager.bestScore[2].ToString();
        fourthScore.text = gameManager.bestScore[3].ToString();
        fifthScore.text = gameManager.bestScore[4].ToString();
        sixtScore.text = gameManager.bestScore[5].ToString();
        seventhScore.text = gameManager.bestScore[6].ToString();
        eightScore.text = gameManager.bestScore[7].ToString();
        ninthScore.text = gameManager.bestScore[8].ToString();
        tenthScore.text = gameManager.bestScore[9].ToString();
    }

    public void GameStartCheck()
    {
        gameManager.gameStart = true;
        LoginSystem.SetActive(false);
        GameStartPopUp.SetActive(false);
        GameSystem.SetActive(true);
        ResultSystem.SetActive(false);
        RestartPopup.SetActive(false);
        GameOver.SetActive(false);
        GameClear.SetActive(false);
        RankingBtn.SetActive(false);
        userName = idInput.text;

        gameManager.gameStart = true;
        gameManager.gameOver = false;
        gameManager.playerScore = 0;
        ballLogic.health = 3;
        ballLogic.started = false;
        ballLogic.rigid.velocity = Vector3.zero;
        playerBall.transform.position = new Vector3(0, -4, 0);
        playerPlane.transform.position = new Vector3(0, -10.25f, 0);
        playerBall.SetActive(true);
        idInput.text = "";
        ballLogic.onPopup = false;
    }
    // 게임시작
    public void GameStart()
    {
        if (!string.IsNullOrEmpty(idInput.text))
        {
            GameStartPopUp.SetActive(true);

            // 블럭들 초기화
            for (int i = 0; i < gameManager.blocks.Length; i++)
            {
                Block blockLogic = gameManager.blocks[i].GetComponent<Block>();
                blockLogic.RandomColor();
                gameManager.blocks[i].SetActive(true);
            }

        }
        else
        {
            CheckUserNamePopUp.SetActive(true);
        }

    }

    public void Restart()
    {
        RestartPopup.SetActive(true);

        // 블럭들 초기화
        for (int i = 0; i < gameManager.blocks.Length; i++)
        {
            Block blockLogic = gameManager.blocks[i].GetComponent<Block>();
            blockLogic.RandomColor();
            gameManager.blocks[i].SetActive(true);
        }
    }

    public void CheckRanking()
    {
        ResultSystem.SetActive(true);
        GameSystem.SetActive(false);
        RankingPopup.SetActive(false);
        GameOver.SetActive(false);
        GameClear.SetActive(false);
        RankingBtn.SetActive(false);

        gameManager.ScoreSet(gameManager.playerScore, userName);
    }

    public void CloseRanking()
    {
        Ranking.SetActive(false);
    }

    public void CheckGameQuit()
    {
        QuitPopup.SetActive(true);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void HomeButton()
    {
        HomePopup.SetActive(true);

        ballLogic.onPopup = true;
    }

    public void GoHome()
    {
        LoginSystem.SetActive(true);
        GameSystem.SetActive(false);
        ResultSystem.SetActive(false);
        HomePopup.SetActive(false);

        gameManager.gameStart = false;
    }
    
    public void RankingPopUp()
    {
        RankingPopup.SetActive(true);

        ballLogic.onPopup = true;
    }

    public void CloseButton()
    {
        QuitPopup.SetActive(false);
        CheckUserNamePopUp.SetActive(false);
        GameStartPopUp.SetActive(false);
        HomePopup.SetActive(false);
        RankingPopup.SetActive(false);
        RestartPopup.SetActive(false);

        ballLogic.onPopup = false;
    }

}
