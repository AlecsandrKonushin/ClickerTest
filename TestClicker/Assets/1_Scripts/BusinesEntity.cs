using Data;

namespace Business
{
    public class BusinesEntity
    {
        public string Name { get; private set; }
        public float TimeRevenue { get; private set; }
        public int BasePrice { get; private set; }
        public int BaseRevenue { get; private set; }
        public UpgradeEntity[] Upgrades { get; private set; }

        public BusinesEntity(BusinessData data)
        {
            Name = data.Name;
            TimeRevenue = data.TimeRevenue;
            BasePrice = data.BasePrice;
            BaseRevenue = data.BaseRevenue;

            Upgrades = new UpgradeEntity[data.Upgrades.Length];

            for (int i = 0; i < data.Upgrades.Length; i++)
            {
                Upgrades[i] = new UpgradeEntity(data.Upgrades[i]);
            }
        }
    }
}
