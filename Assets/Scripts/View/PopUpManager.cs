using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : Singleton<PopUpManager>
{
    [SerializeField] private InfoCountryView _inforCountry;
    [SerializeField] private Button _turnOffButton;
    private bool _isShowingInforCountry = true;

    protected override void Awake()
    {
        base.Awake();
        _turnOffButton.onClick.AddListener(() => HideInforCountry());
    }

    public void UpdateInforCountryView(Country model)
    {
        _inforCountry.UpdateView(model);
    }
    public void ShowInforCountry()
    {
        if (_isShowingInforCountry)
            return;

        _isShowingInforCountry = true;
        _inforCountry.TurnOn();
    }
    public void HideInforCountry()
    {
        if (!_isShowingInforCountry)
            return;

        _isShowingInforCountry = false;
        _inforCountry.TurnOff();
    }

}
