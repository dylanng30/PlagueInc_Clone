using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Refactor_01.Presentation
{
    public class CountrySelectionPresenter
    {
        private readonly CountryViewController _scrollController;
        private readonly InfoCountryView _detailView;

        public CountrySelectionPresenter(CountryViewController scrollController, InfoCountryView detailView)
        {
            _scrollController = scrollController;
            _detailView = detailView;

            _scrollController.OnCountrySnapped += OnCountrySnapped;
            
        }

        private void OnCountrySnapped(CountryView view)
        {
            _detailView.UpdateDetail(view.Model);
            view.AddListener(TurnOn);
        }
        private void TurnOn()
        {
            PopUpManager.Instance.ShowInforCountry();
        }

        //public void Dispose()
        //{
        //    _scrollController.OnCountrySnapped -= OnCountrySnapped;
        //}
    }
}



