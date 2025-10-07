using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiseaseType
{
    Virus,
    Bacteria,
    Parasite,
    Fungus
}

[CreateAssetMenu(fileName = "DiseaseSO")]
public class DiseaseSO : ScriptableObject
{
    public Sprite Avatar;
    public DiseaseType DiseaseType;
    public int minDays;
    public int maxDays;
    public string Description;
}
