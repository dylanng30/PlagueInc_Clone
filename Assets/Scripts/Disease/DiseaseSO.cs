using System.Collections;
using System.Collections.Generic;
using Refactor_01.Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "DiseaseSO")]
public class DiseaseSO : ScriptableObject
{
    public Sprite Avatar;
    public PathogenType PathogenType;
    public int minDays;
    public int maxDays;
    public string Description;
}
