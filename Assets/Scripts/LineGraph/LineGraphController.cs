using System;
using System.Collections.Generic;
using UnityEngine;

public class LineGraphController : MonoBehaviour
{
    public LineGraphRenderer _renderer;
    public float zoom = 1f;
    public float pan = 0f;

    [Header("Offset")]
    public float xOffset;

    [Header("Graph Scaling")]
    public float xSpacing = 0.2f;
    public float yScale = 0.01f;

    [Header("Data")]
    public List<DataPoint> data = new List<DataPoint>();

    private float graphLength;

    void Start()
    {
        DateTime today = DateTime.Today;
        for (int i = 0; i < 100; i++)
        {
            data.Add(new DataPoint(today.AddDays(i), Mathf.Sin(i * 0.1f) * 50 + 200));
        }

        
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

        float graphLength = (data.Count - 1) * xSpacing * zoom; 

        pan = Mathf.Clamp(pan, -(graphLength + xOffset), -xOffset);

        _renderer.DrawGraph(data, zoom, pan, xSpacing, yScale);
    }
}
