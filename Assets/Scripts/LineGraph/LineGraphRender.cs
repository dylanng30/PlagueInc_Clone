using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGraphRenderer : MonoBehaviour
{
    public RectTransform linePrefab;
    public List<RectTransform> lines = new();
    //public PointLG pointPrefab;

    [Header("SETTINGS")]
    [SerializeField] private Vector2 lineOffset;

    public void DrawGraph(List<PointLG> data, float zoom, float pan, float xSpacing, float yScale)
    {
        if (data == null || data.Count < 2)
            return;

        EnsureLineCount(data.Count - 1);

        for (int i = 0; i < data.Count - 1; i++)
        {
            RectTransform startPoint = data[i].GetComponent<RectTransform>();
            SetPointPosition(startPoint, i, data[i].value, zoom, pan, xSpacing, yScale);

            RectTransform endPoint = data[i + 1].GetComponent<RectTransform>();
            SetPointPosition(endPoint, i + 1, data[i + 1].value, zoom, pan, xSpacing, yScale);

            UpdateLine(lines[i], startPoint, endPoint);
        }

    }

    private void EnsureLineCount(int requiredCount)
    {
        while (lines.Count < requiredCount)
        {
            var line = Instantiate(linePrefab, transform);
            lines.Add(line);
        }
    }

    private void SetPointPosition(RectTransform point, int index, float value, float zoom, float pan, float xSpacing, float yScale)
    {
        float x = (index + pan) * xSpacing * zoom;
        float y = value * yScale;
        point.anchoredPosition = new Vector2(x, y);
    }
    private void UpdateLine(RectTransform line, RectTransform start, RectTransform end)
    {
        Vector2 direction = end.anchoredPosition - start.anchoredPosition;
        float length = direction.magnitude;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        line.anchoredPosition = start.anchoredPosition + lineOffset;
        line.sizeDelta = new Vector2(length, line.sizeDelta.y);
        line.localEulerAngles = new Vector3(0, 0, angle);
    }
}