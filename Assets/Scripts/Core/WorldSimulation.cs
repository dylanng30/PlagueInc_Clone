using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSimulation : MonoBehaviour
{
    public DiseaseInstance disease;
    private int day = 0;
    public float curePercent = 0;
    private Dictionary<int,List<(Country, int)>> date_deaths = new Dictionary<int, List<(Country, int)>>();

    public List<TraitData> traitDatas = new List<TraitData>();
    public void CreateDisease(DiseaseData _diseaseData)
    {
        //if(disease != null)
        //{
        //    disease.Reset();
        //}
        disease = new DiseaseInstance(_diseaseData.DiseaseName, _diseaseData.Data);
    }
    public void RegisterInitialCountry(Country country)
    {
        day = 1;
        if(!CountryManager.Instance.AllCountries.Contains(country)) 
            return;

        int initialInfections = 1;
        curePercent = 0;
        disease.ApplyDNA(0);
        ObserverManager.Instance.Notify(EventType.DayChange, day);
        ObserverManager.Instance.Notify(EventType.CureChange, curePercent);
        InfectionManager.DetermineDateOfDeath(country, disease, day, initialInfections, date_deaths);
        country.normal -= initialInfections;
        country.infected += initialInfections;
    }
    public void ResetSimulation()
    {
        day = 0;
        curePercent = 0;
        date_deaths.Clear();
        disease = null;
    }

    public void TickDay(TransitController transitController)
    {
        day++;
        ObserverManager.Instance.Notify(EventType.DayChange, day);
        SimulateWithinCountry();
        transitController.CreateTransit(CountryManager.Instance.OpenCountries, day);
        SimulateCrossCountryInfections(transitController.GetTransitModelsWithDay(day));
        SimulateCure();
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
            InfectionManager.SimulateDNAGain(disease, newInfections);
            
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
            //Debug.Log($"{model.InfectedPassenger} toi {model.ArrivalCountry}");
            InfectionManager.DetermineDateOfDeath(arrivalCountry, disease, day, newInfections, date_deaths);
            InfectionManager.SimulateDNAGain(disease, newInfections);
        }
    }
    //
    private void SimulateCure()
    {
        foreach (var country in CountryManager.Instance.AllCountries)
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
