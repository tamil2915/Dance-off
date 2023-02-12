using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    int noOfHits = 0;

    public TextMeshProUGUI scoreTextUI;
    
    
    public void OnHit()
    {
        noOfHits += 1;

        scoreTextUI.SetText(noOfHits.ToString());
    }
}
