using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionNodeModel
{
    public bool isUnlocked;
    public bool isAvailable;
    public TraitData data;
    public EvolutionNodeModel(TraitData data)
    {
        this.data = data;
        this.isAvailable = data._isAvailable;
        this.isUnlocked = data._isUnlocked;
    }
}
