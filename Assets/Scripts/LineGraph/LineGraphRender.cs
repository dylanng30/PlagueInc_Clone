using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineGraphRenderer : MonoBehaviour
{
    [Header("VIEWS")]
    [SerializeField] private TextMeshPro nameGraph;

    public LinePool linePool;

    [Header("SETTINGS")]
    [SerializeField] private Vector2 lineOffset;

    public void DrawGraph(List<PointLG> data, HumanType type, float zoom, float pan, float xSpacing, float yScale, bool hideOthers = false)
    {
        if (data == null || data.Count < 2)
            return;

        linePool.ReturnAllToPool(type);

        for (int i = 0; i < data.Count - 1; i++)
        {
            RectTransform startPoint = data[i].GetComponent<RectTransform>();
            SetPointPosition(startPoint, i, data[i].value, zoom, pan, xSpacing, yScale);

            RectTransform endPoint = data[i + 1].GetComponent<RectTransform>();
            SetPointPosition(endPoint, i + 1, data[i + 1].value, zoom, pan, xSpacing, yScale);

            var line = linePool.GetLine(type, this.transform);
            UpdateLine(line, startPoint, endPoint);
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