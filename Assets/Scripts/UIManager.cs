using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField idInput;
    public InputField passInput;

    public List<string> idList;
    public List<string> passList;

    public GameObject LoginSystem;

    public GameManager gameManager;

    void Awake()
    {
        idList = new List<string>();
        passList = new List<string>();
    }

    public void MakeUser()
    {
        if(!string.IsNullOrEmpty(idInput.text) && !string.IsNullOrEmpty(passInput.text))
        {
            idList.Add(idInput.text);
            passList.Add(passInput.text);

            idInput.text = "";
            passInput.text = "";
        } else
        {
            Debug.Log("회원가입 실패");
        }
    }

    public void Login()
    {
        if(idList.Contains(idInput.text) && passList.Contains(passInput.text) && idList.IndexOf(idInput.text) == passList.IndexOf(passInput.text))
        {
            gameManager.gameStart = true;
            LoginSystem.SetActive(false);
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }
}
