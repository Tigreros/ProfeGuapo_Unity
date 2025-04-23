using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<string, Action> events = new Dictionary<string, Action>();
    private static Dictionary<string, Action<object, float>> hitEvents = new();
    
    public  static string textGPT = "caca";


    public static void HitSusbcribe(string eventName, Action<object, float> callback)
    {
        if (!hitEvents.ContainsKey(eventName))
        {
            hitEvents[eventName] = callback;
        }
        else
        {
            hitEvents[eventName] += callback;
        }
    }


    public static void HitUnsubscribe(string eventName, Action<object, float> callback)
    {
        if (hitEvents.ContainsKey(eventName))
        {
            hitEvents[eventName] -= callback;
        }
        if (hitEvents[eventName] == null)
        {
            hitEvents.Remove(eventName);
        }
    }


    public static void HitPublish(string eventName, object target, float value)
    {
        if (hitEvents.ContainsKey(eventName))
        {
            hitEvents[eventName]?.Invoke(target, value);
        }
    }




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

    public static void PublishText(string eventName, string text)
    {
        if (events.ContainsKey(eventName))
        {
            textGPT = text;
            events[eventName]?.Invoke();
        }
    }

}