using Data;

namespace Business
{
    public class UpgradeEntity 
    {
        public int Price { get; private set; }
        public int FactorRevenue { get; private set; }

        public UpgradeEntity(UpgradeData data)
        {
            Price = data.Price;
            FactorRevenue = data.FactorRevenue;
        }
    }
}