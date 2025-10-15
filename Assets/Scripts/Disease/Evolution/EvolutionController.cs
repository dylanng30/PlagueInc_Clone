using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using UnityEngine;

public class EvolutionController : Singleton<EvolutionController>
{
    private DiseaseModel currentDisease;
    [SerializeField] private EvolutionTreeView treeView;
    [SerializeField] private InformationTraitView informationTraitView;
    [SerializeField] private InformationDiseaseView diseaseView;

    private TraitData currentSelectedTrait;
    private EvolutionTreeModel treeModel;

    protected override void Awake()
    {
        base.Awake();
    }

    public void RegisterDisease(DiseaseModel disease)
    {
        currentDisease = disease;
        treeModel = new EvolutionTreeModel(currentDisease.Traits);
        treeView.CreateTree(currentDisease, treeModel);
        treeView.OnNodeSelected += HandleNodeSelected;
        informationTraitView.OnEvolvePressed += HandleEvolvePressed;
    }

    private void HandleNodeSelected(TraitData data)
    {
        currentSelectedTrait = data;
        var model = treeModel.nodes[data];
        UpdateInformationTraitView(model);
    }

    private void HandleEvolvePressed()
    {
        if (currentSelectedTrait == null)
            return;

        var model = treeModel.nodes[currentSelectedTrait];
        if (!treeModel.CanEvolve(currentSelectedTrait, currentDisease.DNA_Points))
            return;

        currentDisease.ApplyDNA(-model.data._dnaCost);
        treeModel.Evolve(currentSelectedTrait);
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
