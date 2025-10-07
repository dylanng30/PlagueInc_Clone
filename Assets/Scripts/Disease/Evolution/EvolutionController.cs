using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionController : Singleton<EvolutionController>
{
    private DiseaseInstance currentDisease;
    public EvolutionTreeView treeView;
    public Button[] buttons;

    protected override void Awake()
    {
        base.Awake();
    }

    public void RegisterDisease(DiseaseInstance disease, List<TraitData> traitDatas)
    {
        currentDisease = disease;
        treeView.CreateTree(traitDatas, disease._treeModel);
    }

    public void OnNodeClicked(TraitData data)
    {
        var model = currentDisease._treeModel.nodes[data];

        if (currentDisease._treeModel.CanEvolve(data, currentDisease.dnaPoints))
        {
            currentDisease.dnaPoints -= model.data._dnaCost;
            currentDisease._treeModel.Evolve(data);
            currentDisease.ApplyTrait(model.data);

            treeView.RefreshAll();
        }
    }


}
