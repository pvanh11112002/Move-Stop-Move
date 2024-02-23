using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : UICanvas
{
    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
