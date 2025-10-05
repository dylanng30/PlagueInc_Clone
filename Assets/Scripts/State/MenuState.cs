using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : IState
{
    public CanvasManager _canvasManager;
    public MenuState(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    public void Enter()
    {
        //Debug.Log("MenuState");
        _canvasManager.ShowMenuCanvas();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
    }
}
