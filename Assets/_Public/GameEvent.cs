using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Public
{
    [CreateAssetMenu(fileName ="GameEvent",
        menuName ="ScriptableObjects/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            foreach (var listener in listeners)
                listener.OnEventRaised();
        }

        public void ConfirmListener()
        {
            foreach (var listener in listeners)
                Debug.Log(listener.name);
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }
        public void UnRegisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
