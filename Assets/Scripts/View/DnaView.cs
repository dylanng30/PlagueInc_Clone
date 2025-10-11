using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DnaView : MonoBehaviour, IObserver
{
    [SerializeField] private TextMeshProUGUI dnaText;

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterObserver(EventType.DNAChange, this);
    }

    private void OnDisable()
    {
        ObserverManager.Instance.UnregisterObserver(EventType.DNAChange, this);
    }

    public void Notify(EventType type, object data = null)
    {
        dnaText.text = "DNA: " + data.ToString();
    }

}
