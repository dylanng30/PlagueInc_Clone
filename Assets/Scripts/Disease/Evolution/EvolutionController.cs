using System.Collections.Generic;
using UnityEngine;

public class EvolutionController : Singleton<EvolutionController>
{
    private DiseaseInstance currentDisease;
    [SerializeField] private EvolutionTreeView treeView;
    [SerializeField] private InformationTraitView informationTraitView;
    [SerializeField] private InformationDiseaseView diseaseView;

    private TraitData currentSelectedTrait;

    protected override void Awake()
    {
        base.Awake();
    }

    public void RegisterDisease(DiseaseInstance disease, List<TraitData> traitDatas)
    {
        currentDisease = disease;
        treeView.CreateTree(traitDatas, disease);
        treeView.OnNodeSelected += HandleNodeSelected;
        informationTraitView.OnEvolvePressed += HandleEvolvePressed;
    }

    private void HandleNodeSelected(TraitData data)
    {
        currentSelectedTrait = data;
        var model = currentDisease._treeModel.nodes[data];
        UpdateInformationTraitView(model);
    }

    private void HandleEvolvePressed()
    {
        if (currentSelectedTrait == null)
            return;

        var model = currentDisease._treeModel.nodes[currentSelectedTrait];
        if (!currentDisease._treeModel.CanEvolve(currentSelectedTrait, currentDisease.dnaPoints))
            return;

        currentDisease.ApplyDNA(-model.data._dnaCost);
        currentDisease._treeModel.Evolve(currentSelectedTrait);
        currentDisease.ApplyTrait(model.data);

        treeView.RefreshAll();
        UpdateInformationTraitView(model);
    }

    private void UpdateInformationTraitView(EvolutionNodeModel model)
    {
        informationTraitView.UpdateView(model);
        informationTraitView.TurnOn();
    }
}
