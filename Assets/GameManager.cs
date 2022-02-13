using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ApplyNum {get; set;}
    public int LotteryNum {get; set;}
    public string[] applicantNameArr;

    public bool isTestMode;


    private int isMode = 0;

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
        if(Input.GetKeyDown(KeyCode.Space)){
            if(isMode==0){
                isMode = 1;
                Time.timeScale = 3f;
            }
            else if(isMode==1){
                isMode = 2;
                Time.timeScale = 5f;
            }
            else if(isMode==2){
                isMode = 0;
                Time.timeScale = 1f;
            }
        }
    }

}
