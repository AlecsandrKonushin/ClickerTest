using Core;
using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Business
{
    [System.Serializable]
    public class ChangeTime : UnityEvent<float, float> { }

    public class BusinesEntity: IWaitTimer
    {
        public ChangeTime ChangeTimeEvent = new ChangeTime();
        public UnityEvent ChangeDataEvent = new UnityEvent();

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Revenue { get; private set; }
        public int PriceLevelUp { get; private set; }
        public float CurrentTime { get; private set; }
        public float TimeRevenue { get; private set; }

        private int basePrice;
        private int baseRevenue;

        public UpgradeEntity[] Upgrades { get; private set; }

        public BusinesEntity(BusinessData data)
        {
            Name = data.Name;
            Level = 1;

            CurrentTime = TimeRevenue = data.TimeRevenue;
            PriceLevelUp = basePrice = data.BasePrice;
            Revenue = baseRevenue = data.BaseRevenue;

            Upgrades = new UpgradeEntity[data.Upgrades.Length];

            for (int i = 0; i < data.Upgrades.Length; i++)
            {
                Upgrades[i] = new UpgradeEntity(data.Upgrades[i]);
            }

            TimeManager.Instance.SubscribeOnTimer(this);
        }

        public void ClickLevelUpButton()
        {

        }

        public void TickTimer()
        {
            CurrentTime -= Time.deltaTime;

            if (CurrentTime <= 0)
            {
                Debug.Log("End time");
            }

            ChangeTimeEvent?.Invoke(TimeRevenue, CurrentTime);
        }
    }
}
