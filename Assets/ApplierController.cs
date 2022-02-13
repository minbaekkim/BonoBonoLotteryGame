using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplierController : MonoBehaviour
{
    public int id;
    public Text nameText;
    [SerializeField] private GameObject chocolateObj;
    [SerializeField] private Sprite[] spriteArr;

    private SpriteRenderer selfSR;

    private void Awake() {
        selfSR = transform.Find("Body").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D _col) {
        Debug.Log(_col.gameObject.tag);
        if(_col.gameObject.CompareTag("Bono")){
            selfSR.sprite = spriteArr[1];
            chocolateObj.SetActive(GameSceneManager.Instance.CheckResult(id));
        }
    }

}
