using System.Collections;
using System.Collections.Generic;
using Refactor_01.Data.StaticData;
using Refactor_01.Presentation;
using UnityEngine;

public class ChooseCountryView : MonoBehaviour
{
    [SerializeField] private CountryDataHolder _prefab;
    [SerializeField] private Transform _container;

    public void CreateCountryButtons()
    {
        if (_container.childCount > 0)
        {
            return;
        }

        List<CountrySO> countryDatas = Systems.Instance.ResourceSystem.GetCountrySOs();

        foreach (var data in countryDatas)
        {
            var button = Instantiate(_prefab, _container);
            button.Render(data);
        }
    }
}
