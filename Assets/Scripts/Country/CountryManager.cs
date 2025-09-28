using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryManager : Singleton<Country>
{
    public List<Country> countries = new List<Country>();
    private Dictionary<string, Country > countryMap = new Dictionary<string, Country>();

    protected override void Awake()
    {
        base.Awake();

        foreach (Country country in countries)
        {
            if (!countryMap.ContainsKey(country.countryName))
                countryMap.Add(country.countryName, country);
        }
    }

    public long GetTotalPopulation()
    {
        long total = 0;
        foreach (var country in countries)
        {
            total += country.population;
        }
        return total;
    }

    public long GetTotalInfected()
    {
        long total = 0;
        foreach (var country in countries)
        {
            total += country.infected;
        }
        return total;
    }

    public long GetTotalDead()
    {
        long total = 0;
        foreach (var country in countries)
        {
            total += country.dead;
        }
        return total;
    }

    public long GetCountryPopulation(string name)
    {
        var country = countries.Find(c => c.countryName == name);
        return country != null ? country.population : 0;
    }
    public long GetCountryInfected(string name)
    {
        var country = countries.Find(c => c.countryName == name);
        return country != null ? country.infected : 0;
    }
}
