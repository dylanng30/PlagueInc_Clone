using System.Collections;
using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using TMPro;
using UnityEngine;

public class InformationDiseaseView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameDisease;
    [SerializeField] private TextMeshProUGUI _infectivity;
    [SerializeField] private TextMeshProUGUI _lethality;
    private DiseaseModel _disease;

    private void OnEnable()
    {
        if(_disease != null)
            UpdateView(_disease);
    }
    public void UpdateView(DiseaseModel disease)
    {
        _disease = disease;
        _nameDisease.text = disease.Name;
        _infectivity.text = "Infectivity: " + disease.Infectivity.ToString();
        _lethality.text = "Lethality: " + disease.Lethality.ToString();
    }
}
