using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseNameState : IState
{
    private CanvasManager _canvasManager;
    public DiseaseNameState(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    public void Enter()
    {
        _canvasManager.ShowNameDiseaseCanvas();
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }

}
