using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    private Dictionary<int, string[]> talkData;
    [SerializeField] private GameObject talkPanel;

    private bool isStartTalk = false;

    public static TalkManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;

        talkData = new Dictionary<int, string[]>();
    }

    private void Start() {
        GenerateData();
        StartTalk(1000);
    }

    void GenerateData(){
        talkData.Add(1000, new string[] { 
            "오늘은 신나는 발렌타인데이. 여러분들을 위해 선물을 준비하였습니다.",
            "하지만 이 선물은 "+GameManager.Instance.ApplyNum+"명 중, "+GameManager.Instance.LotteryNum+"명만 드릴 수 있답니다.",
            "과연 어떤 분이 받을지 아주 기대가 되는군요.",
            "그럼 시작해볼까요?",
            });
    }


    private void Update() {
        if(!isStartTalk) return;
        if(Input.GetMouseButtonDown(0)){
          nowTalkIndex++;
          GetTalk(nowId);
        }
    }

    private int nowId = 0;
    private int nowTalkIndex = 0;

    public void StartTalk(int _id){
        if(isStartTalk){
            Debug.LogError("이미 대화중입니다.");
            return;
        } 

        nowId = _id;
        nowTalkIndex = 0;
        
        GetTalk(nowId);

        talkPanel.SetActive(true);
        isStartTalk = true;
    }

    public void GetTalk(int _id){
        string[] tempTalkData = talkData[_id];
        if(tempTalkData.Length == nowTalkIndex)
            EndTalk();
        else
            talkPanel.transform.Find("TalkText").GetComponent<Text>().text = tempTalkData[nowTalkIndex];
    }

    private void EndTalk(){
        talkPanel.SetActive(false);
        isStartTalk = false;
        GameSceneManager.Instance.StartGame();
    }
}
