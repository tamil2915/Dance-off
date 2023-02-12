using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerTextUI;

    float currentTime = 0f;

    private void Update()
    {
        currentTime += Time.deltaTime;

        timerTextUI.SetText(Mathf.Round(currentTime).ToString());
    }
}
