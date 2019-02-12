using System;
using System.Collections;
using System.Collections.Generic;

namespace SnakeU {
    public class NotificationCenter {
        public delegate void EventHandler(Hashtable args);
        Dictionary<string, EventHandler> listeners = new Dictionary<string, EventHandler>();

        public void AddListener(string eventName, EventHandler listener) {
            if(listeners.ContainsKey(eventName)) {
                listeners[eventName] += listener;
            } else {
                listeners[eventName] = listener;
            }
        }

        public void RemoveListener(string eventName, EventHandler listener) {
            if(listeners.ContainsKey(eventName)) {
                listeners[eventName] -= listener;
            }
        }

        public void EmitEvent(string eventName, Hashtable arguments = null) {
            var eventArguments = arguments ?? new Hashtable();

            if(listeners.ContainsKey(eventName)) {
                listeners[eventName].Invoke(eventArguments);
            }
        }
    }
}