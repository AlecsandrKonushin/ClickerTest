using System;
using Business;

namespace SaveSystem
{
    [Serializable]
    public class SaveUpgradeData
    {
        public bool IsBuy;
        public int Id;
        public string Name;
        public int Price, FactorRevenue;

        public SaveUpgradeData(UpgradeEntity upgrade)
        {
            IsBuy = upgrade.IsBuy;
            Id = upgrade.Id;
            Name = upgrade.Name;
            Price = upgrade.Price;
            FactorRevenue = upgrade.FactorRevenue;
        }
    }
}