using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseInstance
{
    public string _name { get; private set; }
    public DiseaseType _type { get; private set; }
    public int _diseaseDuration { get; private set; }

    public float _infectivity {  get; private set; }
    public float _lethality { get; private set; }
    public float _severity { get; private set; }

    public List<TraitData> traits = new List<TraitData>();
    
    public DiseaseInstance(string name, DiseaseSO data)
    {
        _type = data.DiseaseType;
        _name = name;
        _diseaseDuration = Random.Range(data.minDays, data.maxDays);

        _infectivity = 1f;
        _lethality = 1f;
        _severity = 2f;
    }
    public void ApplyTrait(TraitData data)
    {
        traits.Add(data);
        _infectivity += data._infectivityModifier;
        _lethality += data._lethalityModifier;
        _severity += data._severityModifier;
    }

}
