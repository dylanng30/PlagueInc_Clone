using System;
using UnityEngine;
using UnityEngine.UI;

public class CountryViewController : MonoBehaviour
{
    [Header("---COUNTRYVIEW---")]
    public CountryView currentCountryView;

    [Space(10)]
    [Header("---SETUP---")]
    public ScrollRect scrollRect;
    public RectTransform center;
    public float snapSpeed = 10f;

    private RectTransform content;
    private RectTransform currentRect;

    private bool isSnapping = true;
    private float threshold = 1f;


    void Start()
    {
        content = scrollRect.content;
    }

    void Update()
    {        

        if (Input.GetMouseButton(0))
        {
            isSnapping = true;
        }

        if (isSnapping)
        {
            //Debug.Log("SnapToClosestCountry");
            SnapToClosestCountry();
        }

        UpdateStats(currentRect);


    }

    void SnapToClosestCountry()
    {
        float closestDistance = Mathf.Infinity;

        foreach (RectTransform rect in content)
        {
            LowLight(rect);
            Vector3 countryLocalPos = scrollRect.viewport.InverseTransformPoint(rect.position);
            Vector3 centerLocalPos = scrollRect.viewport.InverseTransformPoint(center.position);

            float distance = Mathf.Abs(countryLocalPos.y - centerLocalPos.y);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentRect = rect;
            }
        }

        if (currentRect != null)
        {
            Hightlight(currentRect);
            Vector3 difference = center.position - currentRect.position;
            content.position = Vector3.Lerp(content.position, content.position + difference, Time.deltaTime * snapSpeed);

            if (difference.magnitude < threshold)
            {
                content.position += difference;
                isSnapping = false;
            }
        }
    }

    private void Hightlight(RectTransform rect)
    {
        if (rect.TryGetComponent(out CountryView view))
        {
            var controller = CountryManager.Instance.GetController(view);
            controller.Highlight();
        }
            
    }
    private void LowLight(RectTransform rect)
    {
        if (rect.TryGetComponent(out CountryView view))
        {
            var controller = CountryManager.Instance.GetController(view);
            controller.Lowlight();
        }
    }
    private void UpdateStats(RectTransform rect)
    {
        if (rect.TryGetComponent(out CountryView view))
        {
            var controller = CountryManager.Instance.GetController(view);
            PopUpManager.Instance.UpdateInforCountryView(controller.GetModel());
        }
    }
}
