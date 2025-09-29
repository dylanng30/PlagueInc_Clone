using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineGraphRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.useWorldSpace = false;
    }

    public void DrawGraph(List<DataPoint> data, float zoom, float pan, float xSpacing, float yScale)
    {
        if (data == null || data.Count == 0)
            return;

        lineRenderer.positionCount = data.Count;

        for (int i = 0; i < data.Count; i++)
        {
            float x = (i + pan) * xSpacing * zoom;
            float y = data[i].value * yScale;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
    public Vector3 GetPoint(int index)
    {
        return lineRenderer.GetPosition(index);
    }
}
