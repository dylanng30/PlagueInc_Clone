using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransitView : MonoBehaviour
{
    [SerializeField] private Image _departureCountry;
    [SerializeField] private Image _arrivalCountry;
    private TransitModel _model;
    public void SetUp(TransitModel model)
    {
        _model = model;

        _departureCountry.sprite = _model.DepartureCountry.img;
        _arrivalCountry.sprite = _model.ArrivalCountry.img;
    }
}
