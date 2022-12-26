using System;
using Business;

namespace SaveSystem
{
    [Serializable]
    public class SaveBusinessData
    {
        public bool IsBuy;
        public string Name;
        public int Level, BasePrice, BaseRevenue;
        public float CurrentTime, TimeRevenue;

        public SaveUpgradeData[] UpgradesData;

        public SaveBusinessData(BusinessEntity business)
        {
            IsBuy = business.IsBuy;
            Name = business.Name;
            Level = business.Level;
            CurrentTime = business.CurrentTime;
            TimeRevenue = business.TimeRevenue;
            BasePrice = business.BasePrice;
            BaseRevenue = business.BaseRevenue;

            UpgradesData = new SaveUpgradeData[business.Upgrades.Length];

            for (int i = 0; i < business.Upgrades.Length; i++)
            {
                UpgradesData[i] = new SaveUpgradeData(business.Upgrades[i]);                
            }
        }
    }
}
