using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu, CountrySelect, PathogenSelect, DiseaseName, Playing, Pause
}
public class GameManager : PersistentSingleton<GameManager>
{    
    public WorldSimulation _worldSimulation;
    public StateManager _stateManager;
    public CanvasManager _canvasManager;
    public TransitController _transitController;


    public DiseaseData _diseaseData;
    public DiseaseSO _data;
    public string _name;

    public DiseaseInstance _diseaseInstance;

    private Dictionary<GameState, IState> gameStates;

    protected override void Awake()
    {
        base.Awake();
        _diseaseData = new DiseaseData();
    }

    private void Start()
    {
        LoadGameState();
        
        _stateManager.ChangeState(gameStates[GameState.Menu]);
    }
    public void ChangeState(GameState _state)
    {
        _stateManager.ChangeState(gameStates[_state]);
    }

    public void RegisterPathogenData(DiseaseSO data)
    {
        _data = data;
        _diseaseData.Data = data;
    }
    public void RegisterNameForDisease(string name)
    {
        _name = name;
        _diseaseData.DiseaseName = name;
    }

    private void LoadGameState()
    {
        gameStates = new Dictionary<GameState, IState>()
        {
            { GameState.Menu, new MenuState(_canvasManager) },
            { GameState.CountrySelect, new CountrySelectState(_canvasManager)},
            { GameState.PathogenSelect, new PathogenSelectState(_canvasManager)},
            { GameState.DiseaseName, new DiseaseNameState(_canvasManager)},
            { GameState.Playing, new PlayingState(_canvasManager, _worldSimulation, _diseaseData, _transitController)},
            { GameState.Pause, new PauseState(_canvasManager)}
        };
    }
}
