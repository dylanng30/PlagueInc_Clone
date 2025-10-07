using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiseaseInstance
{
    public string _name { get; private set; }
    public DiseaseType _type { get; private set; }
    public int _diseaseDuration { get; private set; }

    public float _infectivity {  get; private set; }
    public float _lethality { get; private set; }
    public float _severity { get; private set; }

    public int dnaPoints;

    public List<TraitData> traits = new List<TraitData>();

    public EvolutionTreeModel _treeModel;
    
    public DiseaseInstance(string name, DiseaseSO data)
    {
        _type = data.DiseaseType;
        _name = name;
        _diseaseDuration = Random.Range(data.minDays, data.maxDays);
        _infectivity = 1f;
        _lethality = 1f;
        _severity = 2f;

        dnaPoints = 100;

        _treeModel = new EvolutionTreeModel();

        List<TraitData> traitDatas = Systems.Instance.ResourceSystem.GetTraitDatas();
        _treeModel.Initialize(traitDatas);
        EvolutionController.Instance.RegisterDisease(this, traitDatas);

        Debug.Log($"{_name} / {data}");
    }

    public void ApplyTrait(TraitData data)
    {
        traits.Add(data);
        _infectivity += data._infectivityModifier;
        _lethality += data._lethalityModifier;
        _severity += data._severityModifier;
    }

}
