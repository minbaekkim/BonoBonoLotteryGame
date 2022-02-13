using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour
{
    [SerializeField] private GameObject[] nameCellObjArr;


    private void Awake() {
        InitNumber();
    }

    private void InitNumber(){
        for (int i = 0; i < nameCellObjArr.Length; i++)
        {
            GameObject tempObj = nameCellObjArr[i];
            tempObj.transform.Find("NumberText").GetComponent<Text>().text = (i+1).ToString()+"번 지원자:";
        }
    }

    public void SetApplyNumber(int _applyNum){

        for (int i = 0; i < nameCellObjArr.Length; i++)
        {            
            nameCellObjArr[i].SetActive(false);
        }

        for (int i = 0; i < _applyNum; i++)
        {            
            nameCellObjArr[i].SetActive(true);
        }
    }


    public void SaveName(){
        int applyNum = GameManager.Instance.ApplyNum;
        string[] nameArr = new string[applyNum];
        for (int i = 0; i < applyNum; i++)
        {
            nameArr[i] = nameCellObjArr[i].transform.Find("InputField").GetComponent<InputField>().text;
        }
        GameManager.Instance.applicantNameArr = nameArr;
    }
}
