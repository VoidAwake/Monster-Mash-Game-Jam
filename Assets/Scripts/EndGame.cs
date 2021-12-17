using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool ending;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (ending)
        {
            canvasGroup.alpha += Time.deltaTime /3;
        }
    }

    [ContextMenu("end")]
    public void End()
    {
        ending = true;
    }
}
