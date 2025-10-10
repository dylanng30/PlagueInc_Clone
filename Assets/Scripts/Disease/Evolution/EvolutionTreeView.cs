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
    [Header("---BUTTONS---")]
    public Button informationButton;
    public Button transmissionButton;
    public Button symptomButton;
    public Button abilityButton;

    [Header("---PANEL---")]
    public Transform informationContainer;
    public Transform transmissionContainer;
    public Transform symptomContainer;
    public Transform abilityContainer;

    private Dictionary<TraitData, EvolutionNodeView> nodeViews = new();
    private Dictionary<ContainerType, Transform> containers;

    private void Start()
    {
        LoadContainers();
        SetUpButtons();
    }

    public void CreateTree(List<TraitData> nodeDatas, EvolutionTreeModel treeModel)
    {
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
}
