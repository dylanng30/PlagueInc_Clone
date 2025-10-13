using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationDiseaseView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameDisease;
    [SerializeField] private TextMeshProUGUI _infectivity;
    [SerializeField] private TextMeshProUGUI _lethality;
    private DiseaseInstance _disease;

    private void OnEnable()
    {
        if(_disease != null)
            UpdateView(_disease);
    }
    public void UpdateView(DiseaseInstance disease)
    {
        _disease = disease;
        _nameDisease.text = disease._name;
        _infectivity.text = "Infectivity: " + disease._infectivity.ToString();
        _lethality.text = "Lethality: " + disease._lethality.ToString();
    }
}
