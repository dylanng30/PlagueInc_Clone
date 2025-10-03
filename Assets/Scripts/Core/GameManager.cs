using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{   
    Setup,
    Playing,
    Pause,
}
public class GameManager : PersistentSingleton<GameManager>
{    
    public WorldSimulation _worldSimulation;
    public CountryManager _countryManager;

    protected override void Awake()
    {
        base.Awake();
        Initialize();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _worldSimulation.TickDay();
        }
    }

    private void Initialize()
    {
        _countryManager.Init();
        var allCountries = _countryManager.GetAllCountry();
        _worldSimulation.Init(allCountries);
    }
}
