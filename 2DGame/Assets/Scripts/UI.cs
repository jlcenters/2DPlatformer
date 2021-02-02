using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public void SetScoreTxt(int score)
    {
        scoreTxt.text = "Score: " + score.ToString();
    }
}
