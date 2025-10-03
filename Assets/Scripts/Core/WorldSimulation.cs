using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSimulation : MonoBehaviour
{
    public DiseaseInstance disease;
    private List<Country> countries = new List<Country>();

    public int day = 0;

    public void Init(List<Country> allCountries)
    {
        this.countries = allCountries;
    }

    public void TickDay()
    {
        day++;
        SimulateWithinCountryInfections();
    }

    //Mô phỏng lây nhiễm trong nước
    private void SimulateWithinCountryInfections()
    {
        var infections = new Dictionary<Country, (int newInfections, int newDeaths)>();
        foreach (var country in countries)
        {
            InfectionManager.SimulateWithinCountryInfections(country, disease, out int newInfections, out int newDeaths);
            infections[country] = (newInfections, newDeaths);
        }
    }

    //Mô phỏng lây nhiễm giữa các nước
    private void SimulateCrossCountryInfections()
    {
        //Execute
    }
}
