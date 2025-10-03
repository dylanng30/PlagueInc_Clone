using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Country
{
    public string name;
    public long population;
    public Sprite img;


    [Header("Dynamic state")]
    public long infected;
    public long dead;


    [Header("Connections")]
    public List<Country> connectedCountries = new List<Country>();


    [Header("Modifiers")]
    public float healthcareLevel = 1f; // 0..1 lower = worse healthcare
    public float travelOpenness = 1f; // 0..1 lower = closed borders


    public Country(string name, long population, Sprite img)
    {
        this.name = name;
        this.population = population;
        this.img = img;
    }
    public long Susceptible
    {
        get
        {
            long sus = population - infected - dead;
            if (sus > 0)
            {
                return sus;
            }

            return 0;
        }
    }
}
