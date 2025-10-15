using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : IState
{
    private CanvasManager _canvasManager;
    private float time;
    private float timer;

    public EndGameState(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }

    public void Enter()
    {
        _canvasManager.ShowEndGame();
        time = 3f;
        timer = 0;
    }

    public void Execute()
    {
        if(timer >= time)
        {
            GameManager.Instance.ChangeState(GameState.Menu);
            return;
        }

        timer += Time.deltaTime;
    }

    public void Exit()
    {
        _canvasManager.HideEndGame();
    }
}
