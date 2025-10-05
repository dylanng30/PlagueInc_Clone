using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : IState
{
    private CanvasManager _canvasManager;
    private WorldSimulation _worldSimulation;
    public PlayingState(CanvasManager canvasManager, WorldSimulation worldSimulation)
    {
        _canvasManager = canvasManager;
        _worldSimulation = worldSimulation;
    }
    public void Enter()
    {
        //Debug.Log("PlayingState");
        _canvasManager.ShowPlayingCanvas();
        _worldSimulation.RegisterCountries(CountryManager.Instance.Countries);
        _worldSimulation.RegisterInitialCountry(CountryManager.Instance.ChosenCountry);
    }

    public void Execute()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _worldSimulation.TickDay();
        }
    }

    public void Exit()
    {

    }

}
