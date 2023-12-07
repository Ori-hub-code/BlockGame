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

    void Start()
    {
        blockCount = blocks.Length;
    }

    void Update()
    {
        count.text = blockCount.ToString();
    }
}
