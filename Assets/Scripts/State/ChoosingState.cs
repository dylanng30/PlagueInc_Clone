using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingState : IState
{
    private CanvasManager _canvasManager;
    public ChoosingState(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    public void Enter()
    {
        Debug.Log("ChoosingState");
        _canvasManager.ShowChooseCanvas();
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
