using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EvolutionTreeModel
{
    public Dictionary<TraitData, EvolutionNodeModel> nodes = new();

    public EvolutionTreeModel(List<TraitData> nodeDatasOfDisease)
    {
        nodes.Clear();

        List<TraitData> datas = Systems.Instance.ResourceSystem.GetTraitDatas();

        foreach (var data in datas)
        {
            nodes.Add(data, new EvolutionNodeModel(data));
        }

        foreach (var data in nodeDatasOfDisease)
        {
            if (nodes.ContainsKey(data))
                Evolve(data);
        }
    }

    public bool CanEvolve(TraitData nodeData, int dnaPoints)
    {
        if (!nodes.ContainsKey(nodeData))
            return false;

        var node = nodes[nodeData];

        if (node.isUnlocked || !node.isAvailable)
            return false;

        return dnaPoints >= node.data._dnaCost;
    }

    public void Evolve(TraitData nodeData)
    {
        if (!nodes.ContainsKey(nodeData)) return;

        var node = nodes[nodeData];
        node.isUnlocked = true;

        foreach (var childTrait in nodeData.childTraits)
        {
            if(nodes[childTrait].isUnlocked)
                continue;

            nodes[childTrait].isUnlocked = false;
            nodes[childTrait].isAvailable = true;
        }
    }

}
