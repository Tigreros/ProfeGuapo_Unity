using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<string, Action> events = new Dictionary<string, Action>();
    private int ccaca;
    public static void Subscribe(string eventName, Action callback)
    {
        if (!events.ContainsKey(eventName))
        {
            events[eventName] = callback;
        }
        else
        {
            events[eventName] += callback;
        }
    }

    public static void Unsubscribe(string eventName, Action callback)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName] -= callback;
        }
        if (events[eventName] == null)
        {
            events.Remove(eventName);
        }
    }

    public static void Publish(string eventName)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName]?.Invoke();
        }
    }

}