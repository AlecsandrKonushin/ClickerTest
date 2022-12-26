using Data;

namespace Business
{
    public class UpgradeEntity 
    {
        public bool IsBuy { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int FactorRevenue { get; private set; }

        public UpgradeEntity(UpgradeData data)
        {
            IsBuy = false;
            Id = data.Id;
            Name = data.Name;
            Price = data.Price;
            FactorRevenue = data.FactorRevenue;
        }

        public void BuyUpgrade()
        {
            IsBuy = true;
        }
    }
}