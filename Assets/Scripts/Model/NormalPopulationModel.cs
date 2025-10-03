using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NormalPopulationModel
{
    public List<PointLG> normalPopulationPoints = new List<PointLG>();
    private HumanType type = HumanType.Normal;

    public void Register(PointLG point)
    {
        normalPopulationPoints.Add(point);
    }
}
