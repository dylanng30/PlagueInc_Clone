using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu, CountrySelect, PathogenSelect, DiseaseName, Playing, Pause, End
}
public class GameManager : PersistentSingleton<GameManager>
{    
    public WorldSimulation _worldSimulation;
    public StateManager _stateManager;
    public CanvasManager _canvasManager;
    public TransitController _transitController;

    private Dictionary<GameState, IState> gameStates;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        LoadGameState();
        //_stateManager.ChangeState(gameStates[GameState.Menu]);
    }
    public void ChangeState(GameState _state)
    {
        _stateManager.ChangeState(gameStates[_state]);
    }

    private void LoadGameState()
    {

        gameStates = new Dictionary<GameState, IState>()
        {
            { GameState.Menu, new MenuState(_canvasManager) },
            { GameState.PathogenSelect, new PathogenSelectState(_canvasManager)},
            { GameState.CountrySelect, new CountrySelectState(_canvasManager)},
            { GameState.DiseaseName, new DiseaseNameState(_canvasManager)},
            { GameState.Playing, new PlayingState(_canvasManager, _worldSimulation, _transitController)},
            { GameState.Pause, new PauseState(_canvasManager)},
            { GameState.End, new EndGameState(_canvasManager) }
        };

    }
}
