using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : IState
{
    private CanvasManager _canvasManager;
    public EndGameState(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }

    public void Enter()
    {
        _canvasManager.ShowEndGame();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        _canvasManager.HideEndGame();
    }
}
