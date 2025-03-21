using System;
using UnityEngine;

namespace Events
{
    public interface IEventService
    {
        event Action OnUIButton;
        void Event();
    }

    public class EventService : IEventService
    {
        private static EventService _instance;
        public static EventService Instance => _instance ??= new EventService();
        
        public event Action OnUIButton;
        
        private EventService() { }
        
        public void Event()
        {
            OnUIButton?.Invoke();
        }
    }
}