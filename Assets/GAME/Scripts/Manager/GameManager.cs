using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Cài đặt để sertup đầu tiên, thêm cả data nữa
public enum GameState
{
    MainMenu,
    GamePlay,
    Pause
}
public class GameManager : Singleton<GameManager>
{
    #region Khai  báo
    private GameState gameState;
    #endregion

    private void Start()
    {
        ChangeState(GameState.MainMenu);
    }
    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;
    }
    public bool IsState(GameState gameState)
    {
        return this.gameState == gameState;
    }
}
