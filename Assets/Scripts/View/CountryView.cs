using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountryView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Image countryImg;
    [SerializeField] private TextMeshProUGUI countryName;
    [SerializeField] private Button button;
    [SerializeField] private Color highColor;
    [SerializeField] private Color lowColor;
    [SerializeField] private Color textHighColor;

    public void Render(Country country)
    {
        countryName.text = country.name;
        countryImg.sprite = country.img;
    }
    public void AddListener(Action onClick)
    {
        if (button == null)
        {
            Debug.LogError($"{gameObject.name} chưa set button");
            return;
        }

        RemoveListener();
        if (onClick != null)
            button.onClick.AddListener(() => onClick());
    }
    public void RemoveListener()
    {
        if (button == null)
        {
            Debug.LogError($"{gameObject.name} chưa set button");
            return;
        }

        button.onClick.RemoveAllListeners();
    }

    public void Highlight()
    {
        countryImg.color = highColor;
        countryName.color = textHighColor;
    }
    public void Lowlight()
    {
        countryImg.color = lowColor;
        countryName.color = lowColor;
        button.onClick.RemoveAllListeners();
    }
}
