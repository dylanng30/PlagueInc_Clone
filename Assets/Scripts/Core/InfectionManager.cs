using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InfectionManager
{
    public static void SimulateWithinCountryInfections(Country country, DiseaseInstance disease, out int newInfections, out int newDeaths)
    {
        newInfections = 0;
        newDeaths = 0;

        if (country.infected <= 0) return;

        //Effective
        float effectiveInfectivity = Mathf.Max(0f, disease._infectivity * (1f - country.healthcareLevel));
        float effectiveLethality = Mathf.Max(0f, disease._lethality * (1f - country.healthcareLevel * 0.5f));


        float contactRate = 1.0f;
        float susFraction = (country.Susceptible) / (float)Mathf.Max(1, country.population);


        //Infection
        float expectedNew = country.infected * contactRate * effectiveInfectivity * susFraction;
        newInfections = Mathf.FloorToInt(expectedNew);
        // Deaths
        float expectedDeaths = country.infected * effectiveLethality;
        newDeaths = Mathf.FloorToInt(expectedDeaths);


        // Apply
        country.infected += newInfections - newDeaths;
        country.dead += newDeaths;


        // Clamp
        if (country.infected < 0) country.infected = 0;
        if (country.dead > country.population) country.dead = country.population;
    }

    //public static void SimulateCrossCountryInfections(Country country)
    //{

    //}
}
