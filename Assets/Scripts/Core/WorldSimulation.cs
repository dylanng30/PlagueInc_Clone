using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSimulation : MonoBehaviour
{
    public DiseaseInstance disease;
    private List<Country> countries = new List<Country>();

    public DiseaseSO _diseaseData;
    public int day = 0;
    private Dictionary<int,List<(Country, int)>> date_deaths = new Dictionary<int, List<(Country, int)>>();

    public List<TraitData> traitDatas = new List<TraitData>();
    public void CreateDisease()
    {
        disease = new DiseaseInstance("COVID", _diseaseData, traitDatas);
    }
    public void RegisterCountries(List<Country> allCountries)
    {
        countries = allCountries;
    }
    public void RegisterInitialCountry(Country country)
    {
        if(!countries.Contains(country)) 
            return;

        int initialInfections = 1;
        country.normal -= initialInfections;
        country.infected += initialInfections;

        //Testing nation
        //Debug.Log($"GOI LAN {day}------------------------------------------------------");
        //TestMulti(country);
    }

    public void TickDay()
    {
        day++;

        SimulateWithinCountry();
    }

    //Mô phỏng lây nhiễm trong nước
    private void SimulateWithinCountry()
    {
        //Debug.Log($"GOI LAN {day}------------------------------------------------------");
        if (disease == null)
        {
            Debug.Log("Khong co mam benh");
            return;
        }
        if (countries.Count == 0)
        {
            return;
        }

        foreach (var country in countries)
        {
            InfectionManager.SimulateWithinCountryInfections(country, disease, out int newInfections);
            InfectionManager.DetermineDateOfDeath(country, disease, day, newInfections, date_deaths);
            InfectionManager.SimualateWithinCountryDeaths(country, day, date_deaths);
        }
    }

    //Mô phỏng lây nhiễm giữa các nước
    private void SimulateCrossCountryInfections()
    {
        //Execute
    }

    #region ---TESTINNG MULTINATION---
    private void TestMulti(Country country)
    {
        foreach (var ct in countries)
        {
            if (ct == country)
            {
                int initialInfections = 1;
                ct.normal -= initialInfections;
                ct.infected += initialInfections;

                InfectionManager.DetermineDateOfDeath(ct, disease, day, initialInfections, date_deaths);
            }
            else
            {
                int initialInfections = 5;
                ct.normal -= initialInfections;
                ct.infected += initialInfections;

                InfectionManager.DetermineDateOfDeath(ct, disease, day, initialInfections, date_deaths);
            }

            InfectionManager.SimualateWithinCountryDeaths(ct, day, date_deaths);
        }
    }
    #endregion
}
