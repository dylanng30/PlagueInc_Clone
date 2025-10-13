using System.Collections;
using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Refactor_01.Presentation
{
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
            _namePathogen.text = pathogenData.PathogenType.ToString();
            _avatar.sprite = _pathogenData.Avatar;
            _description.text = pathogenData.Description;
            LoadPathogenButton();
        }

        private void LoadPathogenButton()
        {
            _pathogenButton = _pathogenButton == null ? GetComponent<Button>() : _pathogenButton;
            _pathogenButton.onClick.AddListener(() => RegisterPathogenData());
        }

        private void RegisterPathogenData()
        {
            GameContext.DiseaseData = _pathogenData;
            GameManager.Instance.ChangeState(GameState.CountrySelect);
        }
    }

}