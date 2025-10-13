using System.Collections;
using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Refactor_01.Presentation 
{
    public class CountryDataHolder : MonoBehaviour
    {
        [SerializeField] private Image _flag;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Button _chooseButton;
        private CountrySO _data;

        public void Render(CountrySO data)
        {
            _data = data;
            _flag.sprite = _data.Img;
            _name.text = _data.Name;
            _chooseButton.onClick.AddListener(() => Choose());
        }

        private void Choose()
        {
            GameContext.InitialCountryId = _data.ID;
            GameManager.Instance.ChangeState(GameState.DiseaseName);
        }
    }
}
