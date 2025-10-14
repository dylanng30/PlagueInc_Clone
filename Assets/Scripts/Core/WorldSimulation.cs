using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Refactor_01.Domain.Entities;
using Refactor_01.Infrastructure;
using UnityEngine;

public class WorldSimulation : MonoBehaviour
{
    //public DiseaseInstance disease;
    private DiseaseModel _diseaseModel;
    private CountryRepository _countryRepo;
    private int day = 0;
    public float curePercent = 0;
    private Dictionary<int,List<(CountryModel, int)>> date_deaths = new Dictionary<int, List<(CountryModel, int)>>();

    public void RegisterInitialCountry(CountryModel country, DiseaseModel diseaseModel, CountryRepository countryRepo)
    {
        day = 1;
        _diseaseModel = diseaseModel;
        _countryRepo = countryRepo;
        int initialInfections = 1;
        curePercent = 0;
        _diseaseModel.ApplyDNA(0);
        ObserverManager.Instance.Notify(EventType.DayChange, day);
        ObserverManager.Instance.Notify(EventType.CureChange, curePercent);
        InfectionManager.DetermineDateOfDeath(country, _diseaseModel, day, initialInfections, date_deaths);
        country.AddInfected(initialInfections);
    }

    public void TickDay(TransitController transitController)
    {
        day++;
        ObserverManager.Instance.Notify(EventType.DayChange, day);
        SimulateWithinCountry();
        transitController.CreateTransit(_countryRepo.GetAll(), day);
        SimulateCrossCountryInfections(transitController.GetTransitModelsWithDay(day));
        SimulateCure();
    }

    //Mô phỏng lây nhiễm trong nước
    private void SimulateWithinCountry()
    {
        if (_diseaseModel == null)
        {
            Debug.Log("Khong co mam benh");
            return;
        }

        foreach (var country in _countryRepo.GetAll())
        {
            
            InfectionManager.SimulateWithinCountryInfections(country, _diseaseModel, out int newInfections);
            InfectionManager.DetermineDateOfDeath(country, _diseaseModel, day, newInfections, date_deaths);
            InfectionManager.SimualateWithinCountryDeaths(country, day, date_deaths);
            InfectionManager.SimulateDNAGain(_diseaseModel, newInfections);
            
        }
    }

    //Mô phỏng lây nhiễm giữa các nước
     private void SimulateCrossCountryInfections(List<TransitModel> transitModels)
     {
        if (transitModels.Count == 0)
            return;

        foreach (var model in transitModels)
        {
            InfectionManager.SimulateInfectedTransits(model, out int newInfections, out CountryModel arrivalCountry);
            //Debug.Log($"{model.InfectedPassenger} toi {model.ArrivalCountry}");
            InfectionManager.DetermineDateOfDeath(arrivalCountry, _diseaseModel, day, newInfections, date_deaths);
            InfectionManager.SimulateDNAGain(_diseaseModel, newInfections);
        }
    }
    //
    private void SimulateCure()
    {
        foreach (var country in _countryRepo.GetAll())
        {
            InfectionManager.SimulateCure(country, out float newCurePercent);
            curePercent += newCurePercent;
        }
        ObserverManager.Instance.Notify(EventType.CureChange, curePercent);

        if (curePercent >= 1)
        {
            GameManager.Instance.ChangeState(GameState.End);
        }

    }
}
