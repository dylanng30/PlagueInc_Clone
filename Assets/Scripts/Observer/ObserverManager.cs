using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    DayChange,
    DNAChange
}
public class ObserverManager : Singleton<ObserverManager>
{
    private Dictionary<EventType, List<IObserver>> observerDics = new Dictionary<EventType, List<IObserver>>();
    protected override void Awake()
    {
        base.Awake();
    }

    public void RegisterObserver(EventType type, IObserver observer)
    {
        if (observerDics.ContainsKey(type))
        {
            observerDics[type].Add(observer);
            return;
        }

        List<IObserver> observers = new List<IObserver>();
        observers.Add(observer);
        observerDics.Add(type, observers);
    }
    public void UnregisterObserver(EventType type, IObserver observer)
    {
        if (!observerDics.ContainsKey(type) ||
            !observerDics[type].Contains(observer))
            return;

        observerDics[type].Remove(observer);
    }

    public void Notify(EventType type, object data = null)
    {
        foreach (var observer in observerDics[type])
        {
            observer.Notify(type, data);
        }
    }
}
