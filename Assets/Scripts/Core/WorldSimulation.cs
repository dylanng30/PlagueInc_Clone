using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class WorldSimulation : MonoBehaviour
{
    public DiseaseInstance disease;
    public int day = 0;
    private Dictionary<int,List<(Country, int)>> date_deaths = new Dictionary<int, List<(Country, int)>>();

    public List<TraitData> traitDatas = new List<TraitData>();
    public void CreateDisease(DiseaseData _diseaseData)
    {
        disease = new DiseaseInstance(_diseaseData.DiseaseName, _diseaseData.Data);
    }
    public void RegisterInitialCountry(Country country)
    {
        if(!CountryManager.Instance.AllCountries.Contains(country)) 
            return;

        int initialInfections = 1;
        country.normal -= initialInfections;
        country.infected += initialInfections;
    }

    public void TickDay(TransitController transitController)
    {
        day++;
        SimulateWithinCountry();
        transitController.CreateTransit(CountryManager.Instance.OpenCountries, day);
        SimulateCrossCountryInfections(transitController.GetTransitModelsWithDay(day));
    }

    //Mô phỏng lây nhiễm trong nước
    private void SimulateWithinCountry()
    {
        if (disease == null)
        {
            Debug.Log("Khong co mam benh");
            return;
        }
        if (CountryManager.Instance.AllCountries.Count == 0)
        {
            return;
        }

        foreach (var country in CountryManager.Instance.AllCountries)
        {
            InfectionManager.SimulateWithinCountryInfections(country, disease, out int newInfections);
            InfectionManager.DetermineDateOfDeath(country, disease, day, newInfections, date_deaths);
            InfectionManager.SimualateWithinCountryDeaths(country, day, date_deaths);
        }
    }

    //Mô phỏng lây nhiễm giữa các nước
     private void SimulateCrossCountryInfections(List<TransitModel> transitModels)
     {
        if (transitModels.Count == 0)
            return;

        foreach (var model in transitModels)
        {
            InfectionManager.SimulateInfectedTransits(model, out int newInfections, out Country arrivalCountry);
            Debug.Log($"{model.InfectedPassenger} toi {model.ArrivalCountry}");
            InfectionManager.DetermineDateOfDeath(arrivalCountry, disease, day, newInfections, date_deaths);
        }
    }
}
