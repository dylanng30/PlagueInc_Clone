using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGraphRenderer : MonoBehaviour
{
    public RectTransform linePrefab;
    //public PointLG pointPrefab;

    [Header("SETTINGS")]
    [SerializeField] private Vector2 lineOffset;

    void Awake()
    {
    }

    public void DrawGraph(List<PointLG> data, float zoom, float pan, float xSpacing, float yScale)
    {
        if (data == null || data.Count == 0)
            return;

        for (int i = 0; i < data.Count - 1; i++)
        {
            RectTransform previous = data[i].GetComponent<RectTransform>();
            float xPrevious = (i + pan) * xSpacing * zoom;
            float yPrevious = data[i].value * yScale;
            previous.anchoredPosition = new Vector2(xPrevious, yPrevious);

            RectTransform next = data[i + 1].GetComponent<RectTransform>();
            float xNext = (i + 1 + pan) * xSpacing * zoom;
            float yNext = data[i + 1].value * yScale;
            next.anchoredPosition = new Vector2(xNext, yNext);

            Vector2 directionLine = next.anchoredPosition - previous.anchoredPosition;

            RectTransform line = Instantiate(linePrefab, this.transform);
            line.anchoredPosition = previous.anchoredPosition + lineOffset;

            float length = directionLine.magnitude;
            line.sizeDelta = new Vector2(length, lineOffset.y / 2);
            float angle = Mathf.Atan2(directionLine.y, directionLine.x) * Mathf.Rad2Deg;
            line.localEulerAngles = new Vector3(0, 0 , angle); 
        }

    }
    private void DrawPoint()
    {

    }
    private void DrawLine()
    {

    }
}