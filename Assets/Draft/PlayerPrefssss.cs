using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefssss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Lưu điểm số cao
        int highScore = 1000;
        PlayerPrefs.SetInt("HighScore", highScore);
       

        // Lấy điểm số cao
        int retrievedScore = PlayerPrefs.GetInt("HighScore", 0);

        // In ra màn hình Console
        Debug.Log("High Score: " + retrievedScore);
    }
}
