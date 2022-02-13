using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [Header("UI PANEL")]
    [SerializeField] private GameObject resultPanel;

    public List<int> resultNumList = new List<int>();
    private int applyNum = 0;
    private int lotteryNum = 0;

    public static GameSceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
        if(GameManager.Instance.isTestMode){
            GameManager.Instance.ApplyNum = 26;
            GameManager.Instance.LotteryNum = 7;
        }

        GetData();
        MakeRandomNumber();
    }

    private void Start() {
        InitGame();
    }

    private void GetData(){
        applyNum = GameManager.Instance.ApplyNum;
        lotteryNum = GameManager.Instance.LotteryNum;

        Debug.Log("지원자 수: " + applyNum);
        Debug.Log("당첨자 수: " + lotteryNum);
    }

    private void MakeRandomNumber(){
        for (int i = 0; i < lotteryNum;)
        {
            int currentNumber = Random.Range(0, applyNum);
            if (!resultNumList.Contains(currentNumber))
            {
                resultNumList.Add(currentNumber);
                i++;
            }
        }

        resultNumList.Sort();

        foreach(int resultNum in resultNumList){
            Debug.Log("당첨 결과: " +resultNum);
        }
    }

    public bool CheckResult(int _id){
        return resultNumList.Contains(_id) ? true : false;
    }
    
    public void InitGame(){
        Time.timeScale = 0f;
    }

    public void StartGame(){
        Time.timeScale = 1f;
    }

    public void EndGame(){
        Time.timeScale = 0f;
        resultPanel.SetActive(true);
    }

    public void ReturnHome(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
