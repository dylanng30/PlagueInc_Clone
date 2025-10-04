using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{    
    public WorldSimulation _worldSimulation;
    public StateManager _stateManager;
    public CanvasManager _canvasManager;

    public ChoosingState _chooseState;
    public MenuState _menuState;
    public PlayingState _playState;


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _chooseState = new ChoosingState(_canvasManager);
        _menuState = new MenuState(_canvasManager);
        _playState = new PlayingState(_canvasManager, _worldSimulation);
        _stateManager.ChangeState(_menuState);
    }

    public void ChangeState(IState _state)
    {
        _stateManager.ChangeState(_state);
    }
}
