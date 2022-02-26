using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ApplyNum {get; set;}
    public int LotteryNum {get; set;}
    public string[] applicantNameArr;

    public bool isTestMode;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {

    }

}
