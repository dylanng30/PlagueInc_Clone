using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TraitCategory
{
    Transmission,
    Symptom,
    Abilities
}

[CreateAssetMenu(fileName = "TraitSO")]
public class TraitData : ScriptableObject
{
    public string _name;
    public string _description;
    public TraitCategory _traitCategory;

    public float _infectivityModifier;
    public float _lethalityModifier;
    public float _severityModifier;

    public int _dnaCost;
}
