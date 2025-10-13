using System.Collections;
using System.Collections.Generic;
using Refactor_01.Domain.Entities;
using UnityEngine;

namespace Refactor_01.Presentation
{
    public class PlayingView : MonoBehaviour
    {
        [SerializeField] private CountryView _prefab;
        [SerializeField] private Transform _container;
        public void CreateCountryViews()
        {
            if (_container.childCount > 0)
            {
                return;
            }

            List<CountrySO> countrySOs = Systems.Instance.ResourceSystem.GetCountrySOs();

            foreach (var data in countrySOs)
            {
                var _view = Instantiate(_prefab,_container);
                _view.Render(data);
            }
        }
    }
}

