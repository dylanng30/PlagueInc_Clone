using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Refactor_01.Data.StaticData;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{
    private List<CountrySO> countrySOs;
    private List<CountryData> countryDatas;
    private List<DiseaseSO> diseaseSOs;
    private List<TraitData> TraitDatas;

    public List<CountrySO> GetCountrySOs()
    {
        if (countrySOs == null)
        {
            countrySOs = Resources.LoadAll<CountrySO>("SO/Country").ToList();
        }

        return countrySOs;
    }
    public List<TraitData> GetTraitDatas()
    {
        if (TraitDatas == null)
        {
            TraitDatas = Resources.LoadAll<TraitData>("SO/Traits").ToList();
        }

        return TraitDatas;
    }
    public List<DiseaseSO> GetDiseaseSOs()
    {
        if (diseaseSOs == null)
        {
            diseaseSOs = Resources.LoadAll<DiseaseSO>("SO/Disease").ToList();
        }

        return diseaseSOs;

    }

    public List<CountryData> GetCountryDatas()
    {
        if (countryDatas == null)
        {
            countryDatas = Resources.LoadAll<CountryData>("SO/Country").ToList();
        }

        return countryDatas;
    }
}