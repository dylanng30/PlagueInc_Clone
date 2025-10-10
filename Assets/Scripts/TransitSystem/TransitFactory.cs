using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitFactory
{
    public bool TryCreate(List<Country> openCountries,out TransitModel newTransit)
    {
        newTransit = null;
        
        if(openCountries == null || openCountries.Count < 2)
        {
            return false;
        }

        int _departureIndex = 0;
        int _arrivalIndex = 0;
        Country _departureCountry, _arrivalCountry;

        _departureIndex = Random.Range(0, openCountries.Count);
        _departureCountry = openCountries[_departureIndex];

        do
        {
            _arrivalIndex = Random.Range(0, openCountries.Count);
            _arrivalCountry = openCountries[_arrivalIndex];
        } while (_arrivalIndex == _departureIndex);

        long _infectedPassenger = Mathf.FloorToInt(_departureCountry.infected * 0.0001f);
        _infectedPassenger = _infectedPassenger < 1 ? 0 : _infectedPassenger;

        newTransit = new TransitModel()
        {
            DepartureCountry = _departureCountry,
            ArrivalCountry = _arrivalCountry,
            InfectedPassenger = (int)_infectedPassenger
        };

        return true;
    }
}
