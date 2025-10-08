using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CountryManager : Singleton<CountryManager>
{
    private CountrySO _chosenCountrySO;
    public Country ChosenCountry;
    private List<CountryController> controllers = new List<CountryController>();

    private List<Country> countries = new List<Country>();
    public List<Country> AllCountries => countries;
    

    private Dictionary<CountryView, CountryController> controllerMap = new Dictionary<CountryView, CountryController>();

    [SerializeField] private CountryView countryPrefab;
    [SerializeField] private Transform container;

    protected override void Awake()
    {
        base.Awake();
    }
    public void RegisterCountry(CountrySO chosenCountrySO)
    {
        _chosenCountrySO = chosenCountrySO;
        LoadMap();
    }

    public void LoadMap()
    {
        if (container.childCount > 0)
        {
            return;
        }

        List<CountrySO> countrySOs = Systems.Instance.ResourceSystem.CountrySOs;

        foreach (var data in countrySOs)
        {
            var model = new Country(data.Name, data.Population, data.Img);
            countries.Add(model);

            if(data == _chosenCountrySO)
            {
                ChosenCountry = model;
            }

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
    public List<Country> OpenCountries
    {
        get
        {
            List<Country> openCountries = new List<Country>();

            foreach (var country in countries)
            {
                if (country.normal > country.population * 0.5f)
                    openCountries.Add(country);
            }

            return openCountries;
        }
    }
}
