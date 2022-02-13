using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isLoop;

    void Update()
    {
        if(isLoop){
            if(transform.position.x < -40.60812f)
                transform.position += Vector3.right * 40.60812f;
        }
        transform.position -= Vector3.right * moveSpeed * Time.deltaTime * PlayerController.Instance.MoveSpeed;
    }
}
