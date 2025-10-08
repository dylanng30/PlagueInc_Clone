using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitViewPool : MonoBehaviour
{
    private Queue<TransitView> pool = new Queue<TransitView>();
    public TransitView _viewPrefab;

    public TransitView GetTransitView(Transform container)
    {
        TransitView view = null;

        if (pool.Count == 0)
        {
            view = Instantiate(_viewPrefab, container);
        }
        else
        {
            view = pool.Dequeue();
            view.gameObject.SetActive(true);
        }
        return view;
    }
    public void ReturnPool(TransitView view)
    {
        view.gameObject.SetActive(false);
        pool.Enqueue(view);
    }
}
