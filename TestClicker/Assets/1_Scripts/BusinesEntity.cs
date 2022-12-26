using Core;
using Data;
using SaveSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Business
{
    [System.Serializable]
    public class ChangeTime : UnityEvent<float, float> { }

    public class BusinessEntity : IWaitTimer
    {
        public ChangeTime ChangeTimeEvent = new ChangeTime();
        public UnityEvent ChangeDataEvent = new UnityEvent();

        public bool IsBuy { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Revenue { get; private set; }
        public int PriceLevelUp { get; private set; }
        public float CurrentTime { get; private set; }
        public float TimeRevenue { get; private set; }
        public int BasePrice { get; private set; }
        public int BaseRevenue { get; private set; }

        public UpgradeEntity[] Upgrades { get; private set; }

        public BusinessEntity(BusinessData data)
        {
            IsBuy = data.IsBuy;
            Name = data.Name;

            CurrentTime = TimeRevenue = data.TimeRevenue;
            BasePrice = data.BasePrice;
            BaseRevenue = data.BaseRevenue;

            Upgrades = new UpgradeEntity[data.Upgrades.Length];

            for (int i = 0; i < data.Upgrades.Length; i++)
            {
                Upgrades[i] = new UpgradeEntity(data.Upgrades[i]);
            }

            if (IsBuy)
            {
                TimeManager.Instance.SubscribeOnTimer(this);
                Level = 1;
            }
            else
            {
                Level = 0;
            }

            CountData();
        }

        public BusinessEntity(SaveBusinessData data)
        {
            IsBuy = data.IsBuy;
            Name = data.Name;
            Level = data.Level;

            CurrentTime = data.CurrentTime;
            TimeRevenue = data.TimeRevenue;
            BasePrice = data.BasePrice;
            BaseRevenue = data.BaseRevenue;

            Upgrades = new UpgradeEntity[data.UpgradesData.Length];

            for (int i = 0; i < data.UpgradesData.Length; i++)
            {
                Upgrades[i] = new UpgradeEntity(data.UpgradesData[i]);
            }

            if (IsBuy)
            {
                TimeManager.Instance.SubscribeOnTimer(this);
            }

            CountData();
        }

        public void ClickLevelUpButton()
        {
            if (BoxControllers.GetController<MoneyController>().CanBuy(PriceLevelUp))
            {
                BoxControllers.GetController<MoneyController>().BuyEntity(PriceLevelUp);

                if (!IsBuy)
                { 
                    IsBuy = true;
                    TimeManager.Instance.SubscribeOnTimer(this);
                }

                Level++;
                CountData();

                BoxControllers.GetController<SaveController>().Save();
            }
        }

        public void ClickUpgradeButton(int id)
        {
            foreach (var upgrade in Upgrades)
            {
                if (upgrade.Id == id && !upgrade.IsBuy)
                {
                    if (BoxControllers.GetController<MoneyController>().CanBuy(upgrade.Price))
                    {
                        BoxControllers.GetController<MoneyController>().BuyEntity(upgrade.Price);

                        upgrade.BuyUpgrade();

                        CountData();

                        BoxControllers.GetController<SaveController>().Save();
                    }
                }
            }
        }

        public void TickTimer()
        {
            CurrentTime -= Time.deltaTime;

            if (CurrentTime <= 0)
            {
                BoxControllers.GetController<MoneyController>().AddMoney(Revenue);
                CurrentTime = TimeRevenue;

                BoxControllers.GetController<SaveController>().Save();
            }

            ChangeTimeEvent?.Invoke(TimeRevenue, CurrentTime);
        }

        private void CountData()
        {
            PriceLevelUp = BoxControllers.GetController<FormulasController>().GetPriceUpLevel(this);
            Revenue = BoxControllers.GetController<FormulasController>().GetRevenue(this);

            ChangeDataEvent?.Invoke();
        }
    }
}
