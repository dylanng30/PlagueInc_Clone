using System;
using System.Collections.Generic;
using UnityEngine;

public class LineGraphController : MonoBehaviour
{

    public LineGraphRenderer _renderer;

    [Header("Size Camera")]
    public float heightCamera;
    public float widthCamera;

    [Header("Graph Scaling")]
    public float xSpacing = 0.2f;
    public float yScale = 0.01f;

    [Header("Data")]
    public List<DataPoint> data = new List<DataPoint>();

    [Header("DYNAMIC STATISTICS")]
    public float graphLength;
    private float zoom = 1f;
    private float pan = 0f;

    void Start()
    {
        DateTime today = DateTime.Today;
        for (int i = 0; i < 100; i++)
        {
            data.Add(new DataPoint(today.AddDays(i), Mathf.Sin(i * 0.1f) * 50 + 200));
        }

        heightCamera = 2f * Camera.main.orthographicSize;
        widthCamera = heightCamera * Camera.main.aspect;

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

        float halfWidthCamera = widthCamera * 0.5f;

        float requiredPanForLeftAlign = -halfWidthCamera / (xSpacing * zoom);
        float requiredPanForRightAlign = (halfWidthCamera / (xSpacing * zoom)) - (data.Count - 1);

        if (graphLength <= widthCamera)
        {
            pan = -halfWidthCamera;
        }
        else
        {
            pan = Mathf.Clamp(pan, requiredPanForLeftAlign, requiredPanForRightAlign);
        }

        _renderer.DrawGraph(data, zoom, pan, xSpacing, yScale);
    }
}
