using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPanelController : MonoBehaviour
{
    private void OnEnable() {
        StartCoroutine(HidePanel());
    }

    private IEnumerator HidePanel(){
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
