using System.Collections;
using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using UnityEngine;

public class TransitFactory
{
    public bool TryCreate(List<CountryModel> openCountries,out TransitModel newTransit)
    {
        newTransit = null;
        
        if(openCountries == null || openCountries.Count < 2)
        {
            return false;
        }

        int _departureIndex = 0;
        int _arrivalIndex = 0;
        CountryModel _departureCountry, _arrivalCountry;

        _departureIndex = Random.Range(0, openCountries.Count);
        _departureCountry = openCountries[_departureIndex];

        do
        {
            _arrivalIndex = Random.Range(0, openCountries.Count);
            _arrivalCountry = openCountries[_arrivalIndex];
        } while (_arrivalIndex == _departureIndex);

        long _infectedPassenger = Mathf.FloorToInt(_departureCountry.Infected * 0.0001f);

        _infectedPassenger = (long) Mathf.Clamp(_infectedPassenger, 0, _arrivalCountry.Normal);


        newTransit = new TransitModel()
        {
            DepartureCountry = _departureCountry,
            ArrivalCountry = _arrivalCountry,
            InfectedPassenger = (int)_infectedPassenger
        };

        return true;
    }
}
