using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayView : MonoBehaviour, IObserver
{
    [SerializeField] private TextMeshProUGUI dayText;
    private void OnEnable()
    {
        StartCoroutine(Register());
    }
    private IEnumerator Register()
    {
        yield return new WaitUntil(() => ObserverManager.Instance != null);
        ObserverManager.Instance.RegisterObserver(EventType.DayChange, this);
    }
    //private void OnDisable()
    //{
    //    ObserverManager.Instance.UnregisterObserver(EventType.DayChange, this);
    //}
    public void Notify(EventType type, object data = null)
    {
        if (type == EventType.DayChange)
        {
            dayText.text = "D" + data.ToString();
        }
    }
}
