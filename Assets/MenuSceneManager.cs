using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] private ContentController contentController;

    [Header("UI PANEL")]
    [SerializeField] private GameObject inputPanelObj;
    [SerializeField] private GameObject namePanelObj;
    [SerializeField] private GameObject[] alertPanelObjArr;


    [Header("INPUT FIELD")]
    [SerializeField] private InputField applyInputField;
    [SerializeField] private InputField lotteryInputField;

    [Header("TEXT")]
    [SerializeField] private Text lotteryText;

    public int ApplyNum {get; set;}
    public int LotteryNum {get; set;}


    public static MenuSceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Home)){
            GameManager.Instance.isTestMode = true;
            SceneManager.LoadScene(1);
        }
    }

    public void OnClickSubmit(){
        if(applyInputField.text=="" || lotteryInputField.text == ""){
            alertPanelObjArr[1].SetActive(true);
            return;
        }

        int applyNum = GameManager.Instance.ApplyNum = int.Parse(applyInputField.text);
        int lotteryNum = GameManager.Instance.LotteryNum = int.Parse(lotteryInputField.text);

        if(applyNum < 0 || lotteryNum<0){
            alertPanelObjArr[1].SetActive(true);
            return;
        }

        if(applyNum < lotteryNum){
            alertPanelObjArr[1].SetActive(true);
            return;
        }

        if(applyNum > 100){
            alertPanelObjArr[0].SetActive(true);
            return;
        }

        lotteryText.text = "당첨자 수: "+lotteryNum.ToString()+"명";
        contentController.SetApplyNumber(applyNum);
        inputPanelObj.SetActive(false);
        namePanelObj.SetActive(true);
    }


    public void StartGame(){
        contentController.SaveName();
        GameManager.Instance.isTestMode = false;
        SceneManager.LoadScene(1);
    }
}
