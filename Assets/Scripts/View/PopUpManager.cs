using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopUpManager : Singleton<PopUpManager>
{
    [SerializeField] private InfoCountryView _inforCountry;

    protected override void Awake()
    {
        base.Awake();
    }
    
    public void UpdateInforCountryView(Country model)
    {
        _inforCountry.UpdateView(model);
    }
    public void ShowInforCountry()
    {
        _inforCountry.TurnOn();
    }
    public void HideInforCountry()
    {
        StartCoroutine(_inforCountry.TurnOff());
    }


}
