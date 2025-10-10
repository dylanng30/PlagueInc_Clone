using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EvolutionNodeView : MonoBehaviour
{
    public event Action OnNodeClicked;

    public Image icon;
    [SerializeField] private Button evolveButton;
    [SerializeField] private Color hideColor;
    [SerializeField] private Color lockedColor;
    [SerializeField] private Color unlockedColor;
    [SerializeField] private TraitData _staticData;

    private EvolutionNodeModel model;
    public bool Assigned;

    private void OnEnable()
    {
        evolveButton.onClick.AddListener(() => OnNodeClicked?.Invoke());
    }

    public bool CanAssign(EvolutionNodeModel model)
    {
        if(model.data != _staticData)
            return false;

        
        this.model = model;
        //nodeName.text = model.data._name;
        Refresh();
        return true;
    }

    public void Refresh()
    {
        evolveButton.interactable = model.isAvailable;

        if (!model.isAvailable)
        {
            icon.color = hideColor;
            return;
        }
        icon.color = model.isUnlocked ? unlockedColor : lockedColor;
        //icon.sprite = model.isUnlocked ? model.data._sprites[0] : model.data._sprites[1];

    }
}
