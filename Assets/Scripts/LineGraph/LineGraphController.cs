using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using UnityEngine;

public class LineGraphController : MonoBehaviour
{
    [Header("---INJECT---")]
    public HumanType lineGraphType;
    public RectTransform panel;

    [Space(10)]
    [Header("---OTHERS---")]
    public LineGraphRenderer _renderer;
    public PointLG pointPrefab;
    public Transform pointManager;

    private float heightPanel => panel.rect.height;
    private float widthPanel => panel.rect.width;

    [Header("Graph Scaling")]
    private float xSpacing = 50f;
    private float yScale = 10f;

    [Header("Data")]
    public List<PointLG> data = new List<PointLG>();

    [Header("DYNAMIC STATISTICS")]
    public float graphLength;
    private float zoom = 1f;
    public float pan = 0f;

    void Start()
    {
        DateTime today = DateTime.Today;
        for (int i = 0; i < 21; i++)
        {
            PointLG point = Instantiate(pointPrefab, pointManager);
            point.Time = today.AddDays(i);
            point.value = (-i * i + 20 * i) * 2;
            data.Add(point);
        }

        //DrawGraph();
    }

    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;

        if (Mathf.Abs(scroll) > 0.01f)
        {
            zoom = Mathf.Clamp(zoom + scroll * 0.1f, 0.1f, 5f);
        }

        if (Input.GetMouseButton(0))
        {
            pan += Input.GetAxis("Mouse X") * 0.5f;
        }

        graphLength = (data.Count - 1) * xSpacing * zoom;

        float gap = (graphLength - widthPanel) / (xSpacing * zoom);

        if (graphLength < widthPanel)
        {
            pan = 0f;
        }
        else
        {
            pan = Mathf.Clamp(pan, -gap - 0.22f, 0f);
        }

        DrawGraph();
    }
    public void DrawGraph()
    {
        _renderer.DrawGraph(data, zoom, pan, xSpacing, yScale);
    }
}