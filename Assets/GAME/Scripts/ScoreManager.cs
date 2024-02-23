using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //public TextMeshPro score;
    public TextMeshProUGUI score;
    // Update is called once per frame
    void Update()
    {
        score.text = PlayerPrefs.GetInt("Player Score").ToString();
    }
}
