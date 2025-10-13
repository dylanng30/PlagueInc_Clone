using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InfectionManager
{
    #region ---CURE---
    public static void SimulateCure(Country country, out float newCurePercent)
    {
        newCurePercent = 0;

        if(country.normal < country.population * 0.5f)
        {
            newCurePercent = 0.02f;
        }
    }
    #endregion
    #region ---DNA--
    public static void SimulateDNAGain(DiseaseInstance disease, int newInfections)
    {
        int dnaGain = 0;

        dnaGain += Mathf.FloorToInt(newInfections / 1000f);
        dnaGain = Mathf.Clamp(dnaGain, 0, 1);

        if (dnaGain > 0)
        {
            disease.ApplyDNA(dnaGain);
        }
    }
    #endregion
    #region ---Single Nation---
    public static void SimualateWithinCountryDeaths(Country country, int day, Dictionary<int, List<(Country, int)>> date_listDeathsInCountry)
    {
        if (!date_listDeathsInCountry.ContainsKey(day))
        {
            return;
        }

        foreach (var (currentCountry, currentDeaths) in date_listDeathsInCountry[day])
        {
            if (currentCountry != country)
                continue;

            country.infected -= currentDeaths;
            country.dead += currentDeaths;

            //Debug.Log($"Ngày {day}: {currentDeaths} người chết tại {country.name}");
        }

    }
    public static void DetermineDateOfDeath(Country country, DiseaseInstance disease, int day, int newInfections, Dictionary<int, List<(Country,int)>> date_listDeathsInCountry)
    {
        //Dynamic
        int dynamicInfections = Mathf.FloorToInt(country.healthcareLevel * newInfections);
        // Debug.Log(dynamicInfections);
        int dynamicDate = day + disease._diseaseDuration + Random.Range(-1, 2);

        AddDeathsToDate(dynamicInfections, dynamicDate, country, date_listDeathsInCountry);

        //Static
        int staticInfections = newInfections - dynamicInfections;
        //Debug.Log(staticInfections);
        int staticDate = day + disease._diseaseDuration;

        AddDeathsToDate(staticInfections, staticDate, country, date_listDeathsInCountry);
    }
    private static void AddDeathsToDate(int infections, int date, Country country, Dictionary<int, List<(Country, int)>> date_listDeathsInCountry)
    {
        if (!date_listDeathsInCountry.ContainsKey(date))
        {
            date_listDeathsInCountry[date] = new List<(Country, int)>();
        }

        bool found = false;

        for (int i = 0; i < date_listDeathsInCountry[date].Count; i++)
        {
            var (targetCountry, currentDeaths) = date_listDeathsInCountry[date][i];
            if (targetCountry == country)
            {
                date_listDeathsInCountry[date][i] = (targetCountry, currentDeaths + infections);
                //Debug.Log($"{country.name} xac dinh ngay {date} se co {currentDeaths + infections} ng chet");
                found = true;
                break;
            }
        }

        if (!found)
        {
            date_listDeathsInCountry[date].Add((country, infections));
            //Debug.Log($"{country.name} xac dinh ngay {date} se co {infections} ng chet");
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
        
        if(newInfections >= country.normal)
        {
            newInfections = (int) country.normal;
        }

        country.infected += newInfections;
        country.normal -= newInfections;

        //Debug.Log($"{country.name} co them: {newInfections}");

    }
    #endregion

    #region ---Country to Country---
    public static void SimulateInfectedTransits(TransitModel model, out int newInfections, out Country arrivalCountry)
    {
        newInfections = model.InfectedPassenger;
        arrivalCountry = model.ArrivalCountry;

        arrivalCountry.normal -= newInfections;
        arrivalCountry.infected += newInfections;
    }
    #endregion
}
