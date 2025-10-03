using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CountryFactory
{
    public static Country Create(CountrySO data)
    {
        return new Country(data.Name, data.Population, data.Img);
    }
}
