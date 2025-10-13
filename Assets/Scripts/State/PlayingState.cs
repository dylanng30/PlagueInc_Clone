using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : IState
{
    private CanvasManager _canvasManager;
    private WorldSimulation _worldSimulation;
    private DiseaseData _diseaseData;
    private TransitController _transitController;

    public PlayingState(
        CanvasManager canvasManager,
        WorldSimulation worldSimulation,
        DiseaseData diseaseData,
        TransitController transitController
    )
    {
        _canvasManager = canvasManager;
        _worldSimulation = worldSimulation;
        _diseaseData = diseaseData;
        _transitController = transitController;
    }
    public void Enter()
    {
        //Debug.Log("PlayingState");
        _canvasManager.ShowPlayingCanvas();

        //_worldSimulation.ResetSimulation();
        _worldSimulation.CreateDisease(_diseaseData);
        _worldSimulation.RegisterInitialCountry(CountryManager.Instance.ChosenCountry);
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _worldSimulation.TickDay(_transitController);
        }
    }

    public void Exit()
    {
        _canvasManager.HidePlayingCanvas();
    }

}
