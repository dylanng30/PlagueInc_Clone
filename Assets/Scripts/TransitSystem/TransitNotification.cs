using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitNotification : MonoBehaviour
{
    public TransitViewPool _pool;
    private List<TransitView> _views = new List<TransitView>();

    [SerializeField] private Transform container;

    public void Notify(List<TransitModel> transitDatas)
    {
        if (transitDatas == null || transitDatas.Count <= 0) 
            return;

        if(_views.Count > 0)
        {
            foreach (var view in _views)
            {
                _pool.ReturnPool(view);
            }

            _views.Clear();
        }

        foreach (var transitModel in transitDatas)
        {
            var newView = _pool.GetTransitView(container);
            newView.SetUp(transitModel);
            _views.Add(newView);
        }
    }

    
}
