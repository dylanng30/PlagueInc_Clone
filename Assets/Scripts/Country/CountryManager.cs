using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CountryManager : Singleton<CountryManager>
{
    public List<CountrySO> countryDatas = new List<CountrySO>();
    private List<CountryController> controllers = new List<CountryController>();
    private Dictionary<CountryView, CountryController> controllerMap = new Dictionary<CountryView, CountryController>();

    [SerializeField] private CountryView countryPrefab;
    [SerializeField] private Transform container;

    protected override void Awake()
    {
        base.Awake();
    }
    public void Init()
    {
        Load();
    }
    private void Load()
    {
        foreach (var data in countryDatas)
        {
            var model = new Country(data.Name, data.Population, data.Img);
            var view = Instantiate(countryPrefab, container);
            var controller = new CountryController(model, view);
            controllers.Add(controller);
            controllerMap.Add(view, controller);
        }
    }
    public CountryController GetController(CountryView view)
    {
        return controllerMap[view];
    }
    public List<Country> GetAllCountry()
    {
        List<Country> countryList = new List<Country>();
        foreach (var controller in controllers)
        {
            countryList.Add(controller.GetModel());
        }
        return countryList;
    }

    //private void RegisterCountry(Country country)
    //{
    //    if (countryMap.ContainsKey(country.name))
    //    {
    //        Debug.Log($"Đã có nước {country.name}");
    //        return;
    //    }

    //    countryMap.Add(country.name, country);
    //    countries.Add(country);
    //}
    //public List<Country> GetAllCountry()
    //{
    //    return countries;   
    //}

    //#region ---TOTAL---
    //public long GetTotalPopulation()
    //{
    //    long total = 0;
    //    foreach (var country in countryMap.Values)
    //    {
    //        total += country.population;
    //    }
    //    return total;
    //}

    //public long GetTotalInfected()
    //{
    //    long total = 0;
    //    foreach (var country in countryMap.Values)
    //    {
    //        total += country.infected;
    //    }
    //    return total;
    //}

    //public long GetTotalDead()
    //{
    //    long total = 0;
    //    foreach (var country in countryMap.Values)
    //    {
    //        total += country.dead;
    //    }
    //    return total;
    //}
    //#endregion

    //#region ---SINGLE---

    //public long GetCountryPopulation(string name)
    //{
    //    var country = countryMap[name];
    //    if (country == null)
    //    {
    //        Debug.LogError($"Không có nước {name}");
    //        return 0;
    //    }
    //    return country.population;
    //}
    //public long GetCountryInfected(string name)
    //{
    //    var country = countryMap[name];
    //    if(country == null)
    //    {
    //        Debug.LogError($"Không có nước {name}");
    //        return 0;
    //    }
    //    return country.infected;
    //}
    //public long GetCountryDead(string name)
    //{
    //    var country = countryMap[name];
    //    if (country == null)
    //    {
    //        Debug.LogError($"Không có nước {name}");
    //        return 0;
    //    }
    //    return country.dead;
    //}

    //#endregion
}
