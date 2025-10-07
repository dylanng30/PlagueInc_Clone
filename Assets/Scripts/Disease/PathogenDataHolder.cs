using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PathogenDataHolder : MonoBehaviour
{
    [Header("---DISPLAY---")]
    [SerializeField] private TextMeshProUGUI _namePathogen;
    [SerializeField] private Image _avatar;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Button _pathogenButton;

    [Space(10)]    
    [Header("---DATA---")]
    [SerializeField] private DiseaseSO _pathogenData;
    
    public void Initialize(DiseaseSO pathogenData)
    {
        _pathogenData = pathogenData;
        _namePathogen.text = pathogenData.DiseaseType.ToString();
        _avatar.sprite = _pathogenData.Avatar;
        _description.text = pathogenData.Description;
        LoadPathogenButton();
    }

    private void LoadPathogenButton()
    {
        _pathogenButton = GetComponent<Button>();
        _pathogenButton.onClick.AddListener(() => RegisterPathogenData());
    }

    private void RegisterPathogenData()
    {
        GameManager.Instance.RegisterPathogenData(_pathogenData);
        GameManager.Instance.ChangeState(GameState.CountrySelect);
    }
}
