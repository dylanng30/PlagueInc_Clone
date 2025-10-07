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
    public Button[] buttons;
    public Transform informationContainer;
    public Transform transmissionContainer;
    public Transform symptomContainer;
    public Transform abilityContainer;

    private Dictionary<TraitData, EvolutionNodeView> nodeViews = new();

    private void Start()
    {
        buttons[0].onClick.AddListener(() => ShowContainer(ContainerType.Information));
        buttons[1].onClick.AddListener(() => ShowContainer(ContainerType.Transmission));
        buttons[2].onClick.AddListener(() => ShowContainer(ContainerType.Symptom));
        buttons[3].onClick.AddListener(() => ShowContainer(ContainerType.Ability));
    }
    private void ShowContainer(ContainerType type)
    {
        informationContainer.gameObject.SetActive(false);
        transmissionContainer.gameObject.SetActive(false);
        symptomContainer.gameObject.SetActive(false);
        abilityContainer.gameObject.SetActive(false);
        switch (type)
        {
            case ContainerType.Information:
                informationContainer.gameObject.SetActive(true);
                break;
            case ContainerType.Transmission:
                transmissionContainer.gameObject.SetActive(true);
                break;
            case ContainerType.Symptom:
                symptomContainer.gameObject.SetActive(true);
                break;
            case ContainerType.Ability:
                abilityContainer.gameObject.SetActive(true);
                break;
        }
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
}
