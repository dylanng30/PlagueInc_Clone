using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country
{
    public string name;
    public long population;
    public Sprite img;


    [Header("Dynamic state")]
    public long normal;
    public long infected;
    public long dead;


    [Header("Connections")]
    public List<Country> connectedCountries = new List<Country>();

    [Header("Modifiers")]
    public float healthcareLevel = 0.3f;
    public float travelOpenness = 0.1f;


    public Country(string name, long population, Sprite img)
    {
        this.name = name;
        this.population = population;
        this.normal = population;
        infected = 0;
        dead = 0;
        this.img = img;
    }

    public void Reset()
    {
        this.normal = population;
        this.infected = 0;
        this.dead = 0;
    }
}
