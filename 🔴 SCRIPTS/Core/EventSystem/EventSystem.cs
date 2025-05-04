using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystem : MonoBehaviour
{
    private static EventSystem instance;
    public static EventSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventSystem>();
                if (instance == null)
                {
                    GameObject go = new GameObject("EventSystem");
                    instance = go.AddComponent<EventSystem>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private Dictionary<string, UnityEvent> eventDictionary;
    private Dictionary<string, UnityEvent<object>> eventWithDataDictionary;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        eventDictionary = new Dictionary<string, UnityEvent>();
        eventWithDataDictionary = new Dictionary<string, UnityEvent<object>>();
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StartListening(string eventName, UnityAction<object> listener)
    {
        UnityEvent<object> thisEvent = null;
        if (Instance.eventWithDataDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<object>();
            thisEvent.AddListener(listener);
            Instance.eventWithDataDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (Instance == null) return;
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void StopListening(string eventName, UnityAction<object> listener)
    {
        if (Instance == null) return;
        UnityEvent<object> thisEvent = null;
        if (Instance.eventWithDataDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public static void TriggerEvent(string eventName, object data)
    {
        UnityEvent<object> thisEvent = null;
        if (Instance.eventWithDataDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(data);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
} 