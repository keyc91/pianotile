using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard Instance;
    public TextMeshProUGUI text;
    public int scorepoints;

    private void Start()
    {
        Instance = this;
    }
    public void Scoreup(int score)
    {
        scorepoints += score;
        text.text = scorepoints.ToString();
    }
}
