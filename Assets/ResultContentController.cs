using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultContentController : MonoBehaviour
{
    [SerializeField] private GameObject[] nameCellObjArr;


    public void SetApplyName(int _lotteryNum, string[] _nameArr){

        for (int i = 0; i < nameCellObjArr.Length; i++)
        {            
            nameCellObjArr[i].SetActive(false);
        }

        for (int i = 0; i < _lotteryNum; i++)
        {            
            nameCellObjArr[i].SetActive(true);
            nameCellObjArr[i].GetComponent<Text>().text = _nameArr[GameSceneManager.Instance.resultNumList[i]];
        }
    }
}
