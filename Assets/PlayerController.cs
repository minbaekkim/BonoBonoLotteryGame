using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator selfAnim;
    
    public float MoveSpeed {get; set;}

    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        selfAnim = GetComponent<Animator>();
        MoveSpeed = 1f;
    }
    

    private void OnTriggerEnter2D(Collider2D _col) {
        Debug.Log(_col.gameObject.tag);
        if(_col.gameObject.CompareTag("Applier")){
            StartCoroutine(GiveChocolate());
        }
        else if(_col.gameObject.CompareTag("End")){
            MoveSpeed = 0f;
            GameSceneManager.Instance.EndGame();
        }
    }

    private IEnumerator GiveChocolate(){
        MoveSpeed = 0f;
        selfAnim.SetBool("isStop",true);
        yield return new WaitForSeconds(2f);
        selfAnim.SetBool("isStop",false);
        MoveSpeed = 1f;
    }
    
}
