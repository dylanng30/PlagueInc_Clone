using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu, CountrySelect, PathogenSelect, Playing, Pause
}
public class GameManager : PersistentSingleton<GameManager>
{    
    public WorldSimulation _worldSimulation;
    public StateManager _stateManager;
    public CanvasManager _canvasManager;

    public CountrySelectState _countrySelectState;
    public MenuState _menuState;
    public PlayingState _playState;
    public PathogenSelectState _pathogenSelectState;

    public DiseaseInstance _diseaseInstance;
    public DiseaseSO _pathogenData;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _countrySelectState = new CountrySelectState(_canvasManager);
        _menuState = new MenuState(_canvasManager);
        _playState = new PlayingState(_canvasManager, _worldSimulation);
        _pathogenSelectState = new PathogenSelectState(_canvasManager._pathogenSelectCanvas);
        _stateManager.ChangeState(_menuState);
    }

    public void ChangeState(IState _state)
    {
        _stateManager.ChangeState(_state);
    }
    public void ChangeState(GameState _state)
    {
        switch (_state)
        {
            case GameState.Menu:
                _stateManager.ChangeState(_menuState);
                break;
            case GameState.CountrySelect:
                _stateManager.ChangeState(_countrySelectState);
                break;
            case GameState.PathogenSelect:
                _stateManager.ChangeState(_pathogenSelectState);
                break;
            case GameState.Playing:
                _stateManager.ChangeState(_playState);
                break;
            case GameState.Pause:
                //_stateManager.ChangeState(_countrySelectState);
                break;
        }
    }

    public void RegisterPathogenData(DiseaseSO pathogenData)
    {
        _pathogenData = pathogenData;
    }
}
