using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : UICanvas
{
    [SerializeField] public GameObject player;
    private void Update()
    {
        CheckDead();
    }
    public void CheckDead()
    {
        if(player.activeSelf == false)
        {
            SceneManager.LoadSceneAsync(2);
        }    
    }    
}
