using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathogenSelectView : MonoBehaviour
{
    public List<DiseaseSO> diseaseSOs = new List<DiseaseSO>();
    [SerializeField] private PathogenDataHolder _holderPrefab;
    [SerializeField] private Transform _container;
    public void PopUp()
    {

    }
    public void PopDown()
    {

    }
    public void CreateButtons()
    {
        if (_container.childCount > 0)
            return;

        foreach(var data in diseaseSOs)
        {
            PathogenDataHolder holder = Instantiate(_holderPrefab, _container);
            holder.name = data.DiseaseType.ToString() + " Button";
            holder.Initialize(data);
        }
    }
}
