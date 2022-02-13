using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplierSetController : MonoBehaviour
{
    
    [SerializeField] private GameObject applicantObj;
    [SerializeField] private GameObject endObj;

    [SerializeField] private float applicantInterval;
    [SerializeField] private ResultContentController resultContentController;

    public string[] nameArr;

    private void Start()
    {
        ShuffleApplicant();
        MakeApplicant();
        SaveResult();
    }

    private void ShuffleApplicant(){
        nameArr = GameManager.Instance.applicantNameArr;
        nameArr = ShuffleArray(nameArr);
    }

    private T[] ShuffleArray<T>(T[] array)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < array.Length; ++i)
        {
            random1 = Random.Range(0, array.Length);
            random2 = Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }

        return array;
    }

    private void MakeApplicant(){
        int applyNum = GameManager.Instance.ApplyNum;

        for (int i = 0; i < applyNum; i++)
        {
            GameObject tempObj = Instantiate(applicantObj);
            tempObj.transform.SetParent(transform);
            tempObj.transform.localPosition = new Vector2(applicantInterval*i,-4.09f);
            tempObj.GetComponent<ApplierController>().id = i;
            tempObj.GetComponent<ApplierController>().nameText.text = nameArr[i];
        }

        GameObject endTempObj = Instantiate(endObj);
        endTempObj.transform.SetParent(transform);
        endTempObj.transform.localPosition = new Vector2(applicantInterval*applyNum,-4.09f);
    }

    private void SaveResult(){
        resultContentController.SetApplyName(GameManager.Instance.LotteryNum,nameArr);
    }
}
