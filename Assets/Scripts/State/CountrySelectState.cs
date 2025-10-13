using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountrySelectState : IState
{
    private CanvasManager _canvasManager;
    public CountrySelectState(CanvasManager canvasManager)
    {
        _canvasManager = canvasManager;
    }
    public void Enter()
    {
        //Debug.Log("ChoosingState");
        _canvasManager.ShowChooseCanvas();
        ChooseCountryView _view = _canvasManager.ChooseCountryCanvas;
        _view.CreateCountryButtons();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        _canvasManager.HideChooseCanvas();
    }
}
