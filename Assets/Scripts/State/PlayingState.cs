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
    private DiseaseData _diseaseData;
    private TransitController _transitController;


    private CountryRepository _countryRepo;
    private DiseaseModel _disease;

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

        CreateCountries();

        PlayingView _view = _canvasManager.PlayingCanvas;
        _view.CreateCountryViews(_countryRepo.GetAll());


        
        //CreateDisease();

        //_worldSimulation.ResetSimulation();
        //_worldSimulation.CreateDisease(_diseaseData);
        //_worldSimulation.RegisterInitialCountry(GameContext.InitialCountryId);
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

    private void CreateCountries()
    {
        _countryRepo = new CountryRepository();
        CountryFactory factory = new CountryFactory();

        List<CountrySO> countryDatas = Systems.Instance.ResourceSystem.GetCountrySOs();
        List<CountryModel> countries = new List<CountryModel>();

        foreach (CountrySO data in countryDatas)
        {
            var country = factory.Create(data);
            countries.Add(country);
        }

        _countryRepo.Load(countries);        
    }
    private void CreateDisease()
    {
        _disease = new DiseaseModel();
    }
    private void InitialWorld()
    {
        CountryModel country = _countryRepo.GetCountry(GameContext.InitialCountryId);
        _worldSimulation.RegisterInitialCountry(country, _disease);
    }

}
