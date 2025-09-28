using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    public string countryName;
    public long population;
    public long infected;
    public long dead;
    public bool IsBrokenDown => population == 0;

    public Country(string countryName, long population)
    {
        this.countryName = countryName;
        this.population = population;
        this.infected = 0;
        this.dead = 0;
    }
    public void AddInfected(long value)
    {
        if (infected < value) 
            return;

        population -= value;
        infected += value;
    }

    public void AddDead(long value)
    {
        if (infected < value)
            return;

        infected -= value; 
        dead += value;
    }
}
