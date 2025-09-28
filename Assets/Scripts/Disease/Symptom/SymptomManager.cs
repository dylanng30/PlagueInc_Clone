using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymptomManager : Singleton<SymptomManager>
{
    public List<SymptomNode> AvailableSymptomNodes = new List<SymptomNode>();
    public List<SymptomNode> UnlockedSymptomNodes = new List<SymptomNode>();

    protected override void Awake()
    {
        base.Awake();
    }
    public void Start()
    {
        foreach(var node in AvailableSymptomNodes)
        {
            node.IsDisplayed = true;
            node.IsLocked = true;
            node.LoadUI();
        }
    }
    public void UnlockSymptomNode(SymptomNode symptomNode)
    {
        if (!AvailableSymptomNodes.Contains(symptomNode))
            return;

        symptomNode.IsLocked = false;


        AvailableSymptomNodes.Remove(symptomNode);
        UnlockedSymptomNodes.Add(symptomNode);

        foreach (var node in symptomNode.childNodes)
        {
            node.IsLocked = true;
            node.IsDisplayed = true;
            AvailableSymptomNodes.Add(node);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach (var node in AvailableSymptomNodes)
        {
            node.LoadUI();
        }
        foreach (var node in UnlockedSymptomNodes)
        {
            node.LoadUI();
        }
    }



     
}
