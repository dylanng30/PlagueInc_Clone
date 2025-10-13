using System.Collections.Generic;
using Refactor_01.Presentation;
using UnityEngine;

public class PathogenSelectView : MonoBehaviour
{
    [SerializeField] private PathogenDataHolder _prefab;
    [SerializeField] private Transform _container;

    public void CreatePathogenButtons()
    {
        if (_container.childCount > 0)
            return;

        List<DiseaseSO> diseaseSOs = Systems.Instance.ResourceSystem.GetDiseaseSOs();

        foreach(var data in diseaseSOs)
        {
            PathogenDataHolder holder = Instantiate(_prefab, _container);
            holder.name = data.PathogenType.ToString() + " Button";
            holder.Initialize(data);
        }
    }
}
