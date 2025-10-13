using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathogenSelectState : IState
{
    private CanvasManager _canvasManager;
    public PathogenSelectState(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    public void Enter()
    {
        _canvasManager.ShowPathogenSelectCanvas();

        PathogenSelectView _view = _canvasManager.PathogenSelectCanvas;
        _view.CreatePathogenButtons();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        _canvasManager.HidePathogenSelectCanvas();
    }
}
