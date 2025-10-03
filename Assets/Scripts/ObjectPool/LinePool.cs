using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinePool : MonoBehaviour
{
    public Dictionary<HumanType, List<RectTransform>> activeLinesPool = new();
    public Dictionary<HumanType, Queue<RectTransform>> deactiveLinesPool = new();

    public RectTransform linePrefab;

    private void Awake()
    {
        foreach (HumanType type in System.Enum.GetValues(typeof(HumanType)))
        {
            if (type == HumanType.All)
                continue;

            activeLinesPool[type] = new List<RectTransform>();
            deactiveLinesPool[type] = new Queue<RectTransform>();
        }
    }

    public void ReturnToPool(HumanType type, RectTransform line)
    {
        line.gameObject.SetActive(false);
        deactiveLinesPool[type].Enqueue(line);
    }

    public RectTransform GetLine(HumanType type, Transform parent)
    {
        RectTransform line;
        if (deactiveLinesPool[type].Count > 0)
        {
            line = deactiveLinesPool[type].Dequeue();
            line.gameObject.SetActive(true);
        }
        else
        {
            line = Instantiate(linePrefab, parent);
            Image image = line.gameObject.GetComponent<Image>();
            image.color = GetColorByHumanType(type);
        }

        activeLinesPool[type].Add(line);
        return line;
    }

    public void ReturnAllToPool(HumanType type)
    {
        if (activeLinesPool[type].Count == 0)
            return;

        foreach (var line in activeLinesPool[type])
        {
            ReturnToPool(type, line);
        }

        activeLinesPool[type].Clear();
    }
    
    private Color GetColorByHumanType(HumanType type)
    {
        if (type == HumanType.Normal)
            return Color.blue;
        else if (type == HumanType.Infected)
            return Color.green;
        else if (type == HumanType.Dead)
            return Color.red;
        else
            return Color.white;
    }
}
