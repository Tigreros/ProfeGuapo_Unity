using UnityEngine;
using System;
using System.Collections.Generic;

public class EventBusBoom
{
    private static Dictionary<string, Action<Vector3, float, float>> eventsHitBoom = new();

    public static void Subscribe(string eventName, Action<Vector3, float, float> callback)
    {
        if (!eventsHitBoom.ContainsKey(eventName))
        {
            eventsHitBoom[eventName] = callback;
        }
        else
        {
            eventsHitBoom[eventName] += callback;
        }
    }

    public static void Unsubscribe(string eventName, Action<Vector3, float, float> callback)
    {
        if (eventsHitBoom.ContainsKey(eventName))
        {
            eventsHitBoom[eventName] -= callback;
        }
        if (eventsHitBoom[eventName] == null)
        {
            eventsHitBoom.Remove(eventName);
        }
    }

    public static void Publish(string eventName, Vector3 pos, float damage, float radius)
    {
        if (eventsHitBoom.ContainsKey(eventName))
        {
            eventsHitBoom[eventName]?.Invoke(pos, damage, radius);
        }
    }
}

