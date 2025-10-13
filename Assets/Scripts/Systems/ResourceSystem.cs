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
    private List<DiseaseSO> diseaseSOs;
    private List<TraitData> traitDatas;

    private void Awake()
    {
        countrySOs = Resources.LoadAll<CountrySO>("SO/Country").ToList();
        traitDatas = Resources.LoadAll<TraitData>("SO/Traits").ToList();
        diseaseSOs = Resources.LoadAll<DiseaseSO>("SO/Disease").ToList();
    }

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
        if (traitDatas == null)
        {
            traitDatas = Resources.LoadAll<TraitData>("SO/Traits").ToList();
        }

        return traitDatas;
    }
    public List<DiseaseSO> GetDiseaseSOs()
    {
        if (diseaseSOs == null)
        {
            diseaseSOs = Resources.LoadAll<DiseaseSO>("SO/Disease").ToList();
        }

        return diseaseSOs;

    }
}