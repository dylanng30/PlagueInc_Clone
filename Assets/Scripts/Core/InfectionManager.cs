using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InfectionManager
{
    public static void SimualateWithinCountryDeaths(Country country, int day, Dictionary<int, int> date_deaths)
    {
        if (!date_deaths.ContainsKey(day))
        {
            return;
        }

        int newDeaths = date_deaths[day];
        country.infected -= newDeaths;
        country.dead += newDeaths;
        Debug.Log($"Ngay {day} co {newDeaths} nguoi chet");
    }
    public static void DetermineDateOfDeath(Country country, DiseaseInstance disease,int day, int newInfections, Dictionary<int, int> date_deaths)
    { 
        //Dynamic
        int dynamicInfections = Mathf.FloorToInt(country.healthcareLevel * newInfections);
        int dynamicDate = day + disease._diseaseDuration + Random.Range(-1, 1);

        if (date_deaths.ContainsKey(dynamicDate))
        {
            date_deaths[dynamicDate] += dynamicInfections;
        }
        else
        {
            date_deaths.Add(dynamicDate, dynamicInfections);
        }

        //Static
        int staticInfections = newInfections - dynamicInfections;
        int staticDate = day + disease._diseaseDuration;
        if (date_deaths.ContainsKey(staticDate))
        {
            date_deaths[staticDate] += staticInfections;
        }
        else
        {
            date_deaths.Add(staticDate, staticInfections);
        }

        //Debug
        if (country.infected == 0)
            return;

        if(dynamicDate == staticDate)
        {
            Debug.Log($"So nguoi chet vao ngay {dynamicDate}: {date_deaths[dynamicDate]}");
        }
        else
        {
            Debug.Log($"So nguoi chet vao ngay {dynamicDate}: {date_deaths[dynamicDate]}");
            Debug.Log($"So nguoi chet vao ngay {staticDate}: {date_deaths[staticDate]}");
        }

        
    }

    public static void SimulateWithinCountryInfections(Country country, DiseaseInstance disease, out int newInfections)
    {
        newInfections = 0;

        if (country == null ||
            country.infected <= 0 ||
            country.normal <= 0 ||
            disease == null)
            return;

        //Cong thuc: newInfections = country.infected * disease._infectivity * (1 - country.healthcareLevel) * contactRate * country.normal / country.population;

        float effectiveInfectivity = Mathf.Clamp01(disease._infectivity * (1f - country.healthcareLevel));
        float contactRate = 2f;
        float susceptibleFraction = (float) country.normal / (float) country.population;


        float expectNewInfections = country.infected * effectiveInfectivity * contactRate * susceptibleFraction;
        newInfections = Mathf.FloorToInt(expectNewInfections);
        country.infected += newInfections;

        if(newInfections > country.normal)
        {
            newInfections = (int) country.normal;
        }

        country.normal -= newInfections;

        Debug.Log(newInfections);

    }

    //public static void SimulateWithinCountryInfections(Country country, DiseaseInstance disease, out int newInfections, out int newDeaths)
    //{
    //    newInfections = 0;
    //    newDeaths = 0;

    //    if (country == null || disease == null)
    //        return;

    //    if (country.infected <= 0 || country.normal <= 0)
    //        return;



    //    //newInfections = country.infected * disease._infectivity * (1 - country.healthcareLevel) * contactRate * country.normal / country.population;

    //    //Effective
    //    float effectiveInfectivity = Mathf.Clamp01(disease._infectivity * (1f - country.healthcareLevel));
    //    float effectiveLethality = Mathf.Clamp01(disease._lethality * (1f - country.healthcareLevel * 0.5f));

    //    float contactRate = 1.0f;

    //    float susFraction = (country.normal) / (float)Mathf.Max(1, country.population);


    //    //Infection
    //    float expectedNew = country.infected * contactRate * effectiveInfectivity * susFraction;
    //    newInfections = Mathf.FloorToInt(expectedNew);
    //    // Deaths
    //    float expectedDeaths = country.infected * effectiveLethality;
    //    newDeaths = Mathf.FloorToInt(expectedDeaths);


    //    if (newInfections > country.normal)
    //        newInfections = (int)country.normal;

    //    if (newInfections < 2) newInfections = 2;

    //    if (newDeaths > country.infected)
    //        newDeaths = (int)country.infected;


    //    // Apply
    //    country.normal -= newInfections;
    //    country.infected += newInfections - newDeaths;
    //    country.dead += newDeaths;

    //    // Clamp
    //    if (country.normal <= 0)
    //        country.normal = 0;

    //    if (country.infected < 0)
    //        country.infected = 0;

    //    if (country.dead > country.population)
    //        country.dead = country.population;
    //}

    //public static void SimulateCrossCountryInfections(Country country)
    //{

    //}
}
