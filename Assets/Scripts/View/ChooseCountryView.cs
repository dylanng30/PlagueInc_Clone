using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCountryView : MonoBehaviour
{
    [SerializeField] private CountyButtonView buttonPrefab;
    [SerializeField] private Transform buttonContainer;

    private void OnEnable()
    {
        LoadButtons();
    }

    private void LoadButtons()
    {
        if (buttonContainer.childCount > 0)
        {
            return;
        }

        List<CountrySO> countryDatas = Systems.Instance.ResourceSystem.CountrySOs;

        foreach (var data in countryDatas)
        {
            var button = Instantiate(buttonPrefab, buttonContainer);
            button.Render(data);
        }
    }
}
