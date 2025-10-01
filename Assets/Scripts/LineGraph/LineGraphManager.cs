using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HumanType
{
    Normal,
    //Infected,
    //Dead
}
public class LineGraphManager : MonoBehaviour
{
    private Dictionary<HumanType, LineGraphController> lineGraphDics = new Dictionary<HumanType, LineGraphController>();
    [SerializeField] private LineGraphController lineGraph;

    private void Start()
    {
        RectTransform panel = GetComponent<RectTransform>();
        foreach (HumanType type in System.Enum.GetValues(typeof(HumanType)))
        {
            var graph = Instantiate(lineGraph, this.transform);
            graph.lineGraphType = type;
            graph.panel = panel;
            graph.name = "LineGraph_" + type;
            lineGraphDics.Add(type, graph);
        }
    }
}
