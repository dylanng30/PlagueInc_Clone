using System.Collections;
using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using UnityEngine;

namespace Refactor_01.Presentation
{
    public class PlayingView : MonoBehaviour
    {
        [Header("---FACTORY---")]
        [SerializeField] private CountryView _prefab;
        [SerializeField] private Transform _container;

        [Space(10)]
        [Header("--REFERRENCES---")]
        [SerializeField] private CountryViewController _countryViewController;
        [SerializeField] private InfoCountryView _inforView;

        [SerializeField] private DayView _dayView;
        [SerializeField] private DnaView _dnaView;
        [SerializeField] private CureView _cureView;


        private List<CountryView> countryViews = new List<CountryView>();
        private CountrySelectionPresenter _presenter;
        public void CreateCountryViews(List<CountryModel> coutries)
        {
            if (_container.childCount > 0)
            {
                return;
            }

            foreach (var model in coutries)
            {
                var _view = Instantiate(_prefab,_container);
                _view.Render(model);
                countryViews.Add(_view);
            }

            _presenter = new CountrySelectionPresenter(_countryViewController, _inforView);
        }


    }
}

