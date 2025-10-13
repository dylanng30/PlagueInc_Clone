using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : Singleton<PopUpManager>
{

    [Header("---NAVIGATION BAR---")]
    [SerializeField] private GameObject _naviBar;

    [Header("---INFORMATION COUNTRY---")]
    [SerializeField] private InfoCountryView _inforCountry;
    [SerializeField] private Button _turnOffButton;
    private bool _isShowingInforCountry = true;

    [Header("---TRANSIT MANAGEMENT SYSTEM---")]
    [SerializeField] private GameObject tmsPanel;
    [SerializeField] private Button _turnOnTmsButton;
    [SerializeField] private Button _turnOffTmsButton;

    [Header("---EVOLUTION SYSTEM---")]
    [SerializeField] private GameObject esPanel;
    [SerializeField] private Button _turnOnEsButton;
    [SerializeField] private Button _turnOffEsButton;



    protected override void Awake()
    {
        base.Awake();
        _turnOffButton.onClick.AddListener(HideInforCountry);

        _turnOnTmsButton.onClick.AddListener(ShowTMSPanel);
        _turnOffTmsButton.onClick.AddListener(HideTMSPanel);

        _turnOnEsButton.onClick.AddListener(ShowESPanel);
        _turnOffEsButton.onClick.AddListener(HideESPanel);
    }
    public IEnumerator ShowInforCountry()
    {
        if (_isShowingInforCountry)
            yield break;

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

    #region ---TRANSIT MANAGEMENT SYSTEM---
    public void ShowTMSPanel()
    {
        tmsPanel.SetActive(true);
        _naviBar.SetActive(false);
    }
    public void HideTMSPanel()
    {
        tmsPanel.SetActive(false);
        _naviBar.SetActive(true);
    }
    #endregion

    #region ---EVOLUTION SYSTEM---
    public void ShowESPanel()
    {
        esPanel.SetActive(true);
        _naviBar.SetActive(false);
    }
    public void HideESPanel()
    {
        esPanel.SetActive(false);
        _naviBar.SetActive(true);
    }
    #endregion

}
