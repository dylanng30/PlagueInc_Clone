using System.Collections;
using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using UnityEngine;

namespace Refactor_01.Infrastructure
{
    public class CountryRepository
    {
        private Dictionary<int, CountryModel> _countries = new Dictionary<int, CountryModel>();

        public void Load(List<CountryModel> countries)
        {
            _countries.Clear();
            foreach (CountryModel country in countries)
            {
                _countries[country.ID] = country;
            }
        }

        public List<CountryModel> GetAll()
        {
            List<CountryModel> allCountries = new List<CountryModel>();
            foreach (CountryModel country in _countries.Values)
            {
                allCountries.Add(country);
            }

            return allCountries;
        }

        public CountryModel GetCountry(int id)
        {
            return _countries[id];
        }
    }
}


