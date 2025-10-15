using System.Collections.Generic;
using Refactor_01.Infrastructure;
using Refactor_01.Domain.Factories;
using UnityEngine;
using Refactor_01.Data.StaticData;
using Refactor_01.Domain.Entities;
using Refactor_01.Presentation;

public class PlayingState : IState
{
    private CanvasManager _canvasManager;
    private WorldSimulation _worldSimulation;
    private TransitController _transitController;

    private CountryRepository _countryRepo;
    private CountryFactory _factory;
    private DiseaseModel _disease;

    public PlayingState(
        CanvasManager canvasManager,
        WorldSimulation worldSimulation,
        TransitController transitController
    )
    {
        _canvasManager = canvasManager;
        _worldSimulation = worldSimulation;
        _transitController = transitController;
    }
    public void Enter()
    {
        //Debug.Log("PlayingState");
        _canvasManager.ShowPlayingCanvas();
        _transitController.Reset();

        CreateCountries();

        PlayingView _view = _canvasManager.PlayingCanvas;
        _view.CreateCountryViews(_countryRepo.GetAll());
        
        CreateDisease();
        InitialWorld();
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
        _canvasManager.HidePlayingCanvas();
    }

    private void CreateCountries()
    {
        _countryRepo = _countryRepo == null ? new CountryRepository() : _countryRepo;
        _factory = _factory == null ? new CountryFactory() : _factory;

        List<CountrySO> countryDatas = Systems.Instance.ResourceSystem.GetCountrySOs();
        List<CountryModel> countries = new List<CountryModel>();

        foreach (CountrySO data in countryDatas)
        {
            var country = _factory.Create(data);
            countries.Add(country);
        }

        _countryRepo.Load(countries);        
    }
    private void CreateDisease()
    {
        _disease = new DiseaseModel();
        EvolutionController.Instance.RegisterDisease(_disease);
    }
    private void InitialWorld()
    {
        CountryModel country = _countryRepo.GetCountry(GameContext.InitialCountryId);
        _worldSimulation.RegisterInitialCountry(country, _disease, _countryRepo, _transitController);
    }

}
