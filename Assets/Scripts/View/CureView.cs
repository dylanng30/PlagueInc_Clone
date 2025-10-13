using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CureView : MonoBehaviour, IObserver
{
    [SerializeField] private Image cureImage;

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterObserver(EventType.CureChange, this);
    }
    //private void OnDisable()
    //{
    //    ObserverManager.Instance.UnregisterObserver(EventType.CureChange, this);
    //}

    public void Notify(EventType type, object data = null)
    {
        Debug.Log("Cure");
        if (data is float fillValue)
        {
            cureImage.fillAmount = fillValue;
        }
    }
}
