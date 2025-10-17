using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class LineGraphController : MonoBehaviour
{
    [Header("---LINEGRAPH---")]
    public HumanType currentLineGraphType;
    [SerializeField] private LineGraphRenderer _normalRenderer;
    [SerializeField] private LineGraphRenderer _infectedRenderer;
    [SerializeField] private LineGraphRenderer _deadRenderer;

    //Sử dụng key để lấy LineGraphRender và Data
    private Dictionary<HumanType, (LineGraphRenderer renderer, List<PointLG> data)> graphMap;

    [Space(10)]
    [Header("---BUTTONS---")]
    [SerializeField] private Button allButton;
    [SerializeField] private Image allButtonImg;
    [Space(5)]
    [SerializeField] private Button normalButton;
    [SerializeField] private Image normalButtonImg;
    [Space(5)]
    [SerializeField] private Button infectedButton;
    [SerializeField] private Image infectedButtonImg;
    [Space(5)]
    [SerializeField] private Button deadButton;
    [SerializeField] private Image deadButtonImg;

    [Space(10)]
    [Header("---COLOR---")]
    [SerializeField] private Color chosenColor;
    [SerializeField] private Color normalColor;

    [Space(10)]
    [Header("---PANELS")]
    public RectTransform lineGraphPanel;
    

    [Space(10)]
    [Header("---OTHERS---")]
    public PointLG pointPrefab;

    [Header("Data")]
    public List<PointLG> normalPopulation = new List<PointLG>();
    public List<PointLG> infectedPopulation = new List<PointLG>();
    public List<PointLG> deadPopulation = new List<PointLG>();

    [Header("SETTINGS")]
    [SerializeField] private float xSpacing;
    [SerializeField] private float yScale;
    private float graphLength;
    private float zoom = 1f;
    private float pan = 0f;
    private float heightPanel => lineGraphPanel.rect.height;
    private float widthPanel => lineGraphPanel.rect.width;

    private void Awake()
    {
        graphMap = new Dictionary<HumanType, (LineGraphRenderer renderer, List<PointLG> data)>
        {
            { HumanType.Normal, (_normalRenderer, normalPopulation) },
            { HumanType.Infected, (_infectedRenderer, infectedPopulation) },
            { HumanType.Dead, (_deadRenderer, deadPopulation) }
        };
    }
    void Start()
    {
        AddListenerToButtons();

        DateTime today = DateTime.Today;
        for (int i = 0; i < 21; i++)
        {
            PointLG normalPoint = Instantiate(pointPrefab, _normalRenderer.transform);
            normalPoint.Time = today.AddDays(i);
            normalPoint.value = (-i * i + 10 * i);
            normalPopulation.Add(normalPoint);

            PointLG infectedPoint = Instantiate(pointPrefab, _infectedRenderer.transform);
            infectedPoint.Time = today.AddDays(i);
            infectedPoint.value = (i * i - 5 * i);
            infectedPopulation.Add(infectedPoint);
        }

        DrawGraph(HumanType.All);
    }

    void Update()
    {
        if (!CanModify)
        {
            //Debug.Log("Nothing changes");
            return;
        }

        DrawGraph(currentLineGraphType);
    }
    #region ---DRAW METHODS---
    public void DrawGraph(HumanType type)
    {
        currentLineGraphType = type;
        //Debug.Log($"LineGraph: {type}");
        if (type == HumanType.All)
        {
            foreach (var graph in graphMap)
            {
                ShowGraph(type);
                graph.Value.renderer.DrawGraph(graph.Value.data, graph.Key, zoom, pan, xSpacing, yScale);
            }
        }
        else if (graphMap.TryGetValue(type, out var graph))
        {
            ShowGraph(type);
            graph.renderer.DrawGraph(graph.data, type, zoom, pan, xSpacing, yScale);
        }

    }
    #endregion

    #region ---HELPER---
    private void AddListenerToButtons()
    {
        allButton.onClick.AddListener(() => DrawGraph(HumanType.All));
        normalButton.onClick.AddListener(() => DrawGraph(HumanType.Normal));
        infectedButton.onClick.AddListener(() => DrawGraph(HumanType.Infected));
        deadButton.onClick.AddListener(() => DrawGraph(HumanType.Dead));
    }
    private bool CanModify => IsZooming() || IsPaning();
    private bool IsZooming()
    {
        float scroll = Input.mouseScrollDelta.y;

        if (Mathf.Abs(scroll) > 0.01f)
        {
            zoom = Mathf.Clamp(zoom + scroll * 0.1f, 0.1f, 5f);
            return true;
        }
        return false;
    }
    private bool IsPaning()
    {
        if (Input.GetMouseButton(0))
        {
            pan += Input.GetAxis("Mouse X") * 0.5f;
            graphLength = (normalPopulation.Count - 1) * xSpacing * zoom;

            float gap = (graphLength - widthPanel) / (xSpacing * zoom);

            if (graphLength < widthPanel)
            {
                pan = 0f;
            }
            else
            {
                pan = Mathf.Clamp(pan, -gap - 0.22f, 0f);
            }
            return true;
        }

        return false;       

    }

    private void ShowGraph(HumanType humanType)
    {
        HideAllGraphs();

        if (humanType == HumanType.All)
        {
            foreach (var graph in graphMap.Values)
                graph.renderer.gameObject.SetActive(true);
        }
        else if (graphMap.ContainsKey(humanType))
        {
            graphMap[humanType].renderer.gameObject.SetActive(true);
        }

        switch (humanType)
        {
            case HumanType.All:
                allButtonImg.color = chosenColor;
                break;
            case HumanType.Normal:
                normalButtonImg.color = chosenColor;
                break;
            case HumanType.Infected:
                infectedButtonImg.color = chosenColor;
                break;
            case HumanType.Dead:
                deadButtonImg.color = chosenColor;
                break;
        }
    }

    private void HideAllGraphs()
    {
        foreach (var graph in graphMap.Values)
            graph.renderer.gameObject.SetActive(false);

        allButtonImg.color = normalColor;
        normalButtonImg.color = normalColor;
        infectedButtonImg.color = normalColor;
        deadButtonImg.color = normalColor;
    }
    #endregion
}