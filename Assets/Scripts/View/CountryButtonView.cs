using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountryButtonView : MonoBehaviour
{
    [SerializeField] private Image _flag;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Button _chooseButton;
    private CountrySO _data;

    private void OnEnable()
    {
        _chooseButton.onClick.AddListener(() => Choose());
    }
    private void OnDisable()
    {
        _chooseButton.onClick.RemoveAllListeners();
    }
    public void Render(CountrySO data)
    {
        _data = data;
        _flag.sprite = _data.Img;
        _name.text = _data.Name;
    }

    private void Choose()
    {
        CountryManager.Instance.RegisterCountry(_data);
        GameManager.Instance.ChangeState(GameState.DiseaseName);
    }
}
