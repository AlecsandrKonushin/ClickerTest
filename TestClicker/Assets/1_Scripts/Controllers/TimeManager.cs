using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class TimeManager : Singleton<TimeManager>
    {
        private List<IWaitTimer> waitingObjects = new List<IWaitTimer>();

        public void SubscribeOnTimer(IWaitTimer waitingObject)
        {
            waitingObjects.Add(waitingObject);
        }

        public void UnsubscribOnTimer(IWaitTimer waitingObject)
        {
            if (waitingObjects.Contains(waitingObject))
            {
                waitingObjects.Remove(waitingObject);
            }
        }

        public void Update()
        {
            if (waitingObjects.Count > 0)
            {
                for (int i = 0; i < waitingObjects.Count; i++)
                {
                    waitingObjects[i].TickTimer();
                }
            }
        }
    }
}