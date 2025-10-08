using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitController : MonoBehaviour
{
    private TransitFactory _factory = new TransitFactory();
    public TransitNotification _transitNoti;
    private Dictionary<int, List<TransitModel>> transits = new Dictionary<int, List<TransitModel>>();

    public void CreateTransit(List<Country> openCountries, int day)
    {
        List<TransitModel> transitModels = new List<TransitModel>();

        int transitCount = Random.Range(2, 5);

        for (int i = 0; i < transitCount; i++)
        {
            if (_factory.TryCreate(openCountries, out TransitModel newTransit))
            {
                transitModels.Add(newTransit);
            }
        }

        transits.Add(day, transitModels);

        _transitNoti.Notify(transitModels);
    }

    public List<TransitModel> GetTransitModelsWithDay(int day)
    {
        List < TransitModel > list = new List<TransitModel>();

        if (transits.ContainsKey(day))
        {
            list = transits[day];
        }

        return list;
    }
}
