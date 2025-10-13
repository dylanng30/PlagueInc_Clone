using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ContainerType
{
    Information,
    Transmission,
    Symptom,
    Ability
}


public class EvolutionTreeView : MonoBehaviour
{
    public event Action<TraitData> OnNodeSelected;

    [Header("---INFORMATION DISEASE---")]
    [SerializeField] private InformationDiseaseView _diseaseView;

    [Header("---BUTTONS---")]
    [SerializeField] private Button informationButton;
    [SerializeField] private Image informationButtonImg;
    [Space(5)]
    [SerializeField] private Button transmissionButton;
    [SerializeField] private Image transmissionButtonImg;
    [Space(5)]
    [SerializeField] private Button symptomButton;
    [SerializeField] private Image symptomButtonImg;
    [Space(5)]
    [SerializeField] private Button abilityButton;
    [SerializeField] private Image abilityButtonImg;

    [Space(10)]
    [Header("---PANEL---")]
    [SerializeField] private Transform informationContainer;
    [SerializeField] private Transform transmissionContainer;
    [SerializeField] private Transform symptomContainer;
    [SerializeField] private Transform abilityContainer;

    [Space(10)]
    [Header("---COLOR---")]
    [SerializeField] private Color chosenColor;
    [SerializeField] private Color normalColor;

    private Dictionary<TraitData, EvolutionNodeView> nodeViews = new();
    private Dictionary<ContainerType, Transform> containers;

    private void Start()
    {
        LoadContainers();
        SetUpButtons();
    }

    public void CreateTree(List<TraitData> nodeDatas, DiseaseInstance disease)
    {
        _diseaseView.UpdateView(disease);
        EvolutionTreeModel treeModel = disease._treeModel;
        foreach (var data in nodeDatas)
        {
            Transform parent = GetContainer(data._traitCategory);
            foreach (Transform child in parent)
            {
                EvolutionNodeView nodeView = child.GetComponent<EvolutionNodeView>();
                if (nodeView == null)
                    continue;

                EvolutionNodeModel nodeModel = treeModel.nodes[data];

                if (!nodeView.CanAssign(nodeModel))
                    continue;

                nodeViews[data] = nodeView;
                nodeView.OnNodeClicked += () => OnNodeSelected?.Invoke(data);
            }            
        }
    }

    private Transform GetContainer(TraitCategory type)
    {
        return type switch
        {
            TraitCategory.Transmission => transmissionContainer,
            TraitCategory.Symptom => symptomContainer,
            TraitCategory.Ability => abilityContainer,
            _ => transform
        };
    }

    public void RefreshAll()
    {
        foreach (var node in nodeViews.Values)
            node.Refresh();
    }

    private void ShowContainer(ContainerType type)
    {
        foreach (var container in containers.Values)
            container.gameObject.SetActive(false);

        if (containers.TryGetValue(type, out var targetContainer))
            targetContainer.gameObject.SetActive(true);

        HighlightButton(type);
    }

    private void LoadContainers()
    {
        containers = new Dictionary<ContainerType, Transform>
        {
            { ContainerType.Information, informationContainer },
            { ContainerType.Transmission, transmissionContainer },
            { ContainerType.Symptom, symptomContainer },
            { ContainerType.Ability, abilityContainer },
        };
    }
    private void SetUpButtons()
    {
        informationButton.onClick.AddListener(() => ShowContainer(ContainerType.Information));
        transmissionButton.onClick.AddListener(() => ShowContainer(ContainerType.Transmission));
        symptomButton.onClick.AddListener(() => ShowContainer(ContainerType.Symptom));
        abilityButton.onClick.AddListener(() => ShowContainer(ContainerType.Ability));
    }

    private void HighlightButton(ContainerType type)
    {
        informationButtonImg.color = normalColor;
        transmissionButtonImg.color = normalColor;
        symptomButtonImg.color = normalColor;
        abilityButtonImg.color = normalColor;

        switch (type)
        {
            case ContainerType.Information:
                informationButtonImg.color = chosenColor;
                break;
            case ContainerType.Transmission:
                transmissionButtonImg.color = chosenColor;
                break;
            case ContainerType.Symptom:
                symptomButtonImg.color = chosenColor;
                break;
            case ContainerType.Ability:
                abilityButtonImg.color = chosenColor;
                break;
        }
    }

}
