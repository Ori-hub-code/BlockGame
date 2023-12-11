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

    public GameManager gameManager;
    public Ball ballLogic;

    public GameObject playerBall;
    public GameObject playerPlane;

    public Text count;
    public Text score;
    public Text health;

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
    }

    public void MakeUser()
    {
        if (!string.IsNullOrEmpty(idInput.text) && !string.IsNullOrEmpty(passInput.text))
        {
            idList.Add(idInput.text);
            passList.Add(passInput.text);

            Debug.Log("ID : " + idInput.text + "    PW : " + passInput.text);

            idInput.text = "";
            passInput.text = "";
        }
        else
        {
            Debug.Log("회원가입 실패");
        }
    }

    public void Login()
    {
        if (idList.Contains(idInput.text) && passList.Contains(passInput.text) && idList.IndexOf(idInput.text) == passList.IndexOf(passInput.text))
        {
            gameManager.gameStart = true;
            LoginSystem.SetActive(false);
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }

    public void Restart()
    {
        gameManager.gameStart = true;
        gameManager.gameOver = false;
        gameManager.playerScore = 0;
        gameManager.blockCount = gameManager.blocks.Length;
        GameOver.SetActive(false);

        playerBall.SetActive(true);
        playerPlane.transform.position = new Vector3(0, -10.25f, 0);

        // 블럭들 초기화
        for (int i = 0; i < gameManager.blocks.Length; i++)
        {
            Block blockLogic = gameManager.blocks[i].GetComponent<Block>();
            blockLogic.RandomColor();
            gameManager.blocks[i].SetActive(true);
        }
    }

    public struct User
    {
        string id;
        string pass;
    }
}
