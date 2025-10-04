using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSimulation : MonoBehaviour
{
    public DiseaseInstance disease;
    private List<Country> countries = new List<Country>();

    public DiseaseSO _diseaseData;
    public int day = 0;
    private Dictionary<int, int> date_deaths = new Dictionary<int, int>();

    public void RegisterCountry(List<Country> allCountries)
    {
        this.countries = allCountries;
        disease = new DiseaseInstance("COVID", _diseaseData);
        date_deaths.Add(disease._diseaseDuration, 1);
    }

    public void TickDay()
    {
        day++;
        SimulateWithinCountry();
    }

    //Mô phỏng lây nhiễm trong nước
    private void SimulateWithinCountry()
    {
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
}
