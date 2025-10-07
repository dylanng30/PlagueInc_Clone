using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TraitCategory
{
    Transmission,
    Symptom,
    Ability
}

[CreateAssetMenu(fileName = "TraitSO")]
public class TraitData : ScriptableObject
{
    public string _name;
    public Sprite[] _sprites;
    public string _description;
    public TraitCategory _traitCategory;
    public bool _isUnlocked;
    public bool _isAvailable;
    public TraitData[] childTraits;

    public float _infectivityModifier;
    public float _lethalityModifier;
    public float _severityModifier;

    public int _dnaCost;
}
